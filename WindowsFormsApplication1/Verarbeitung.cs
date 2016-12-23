using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient; //MySql.Data.MySqlClient;

namespace WindowsFormsApplication1
{
    class Verarbeitung1
    {
       // public string fontFace, fontSize;
        public List<string[]> list = new List<string[]>();
        public List<string> mlist = new List<string>();
        public List<string> llist = new List<string>();

        public List<OcrWord> ocrList = new List<OcrWord>();
        public List<OcrWord> combinedTextList = new List<OcrWord>();
        //public string sr;
        //public int zaehler;
        //public int b, l, r, t;
        String ErlaubteZeichen = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789äöüÄÖÜß.,-:;_/=()&!?%*";
        int maxXDistance = 40;
        //int textWidthTolerance = 80;
        int maxYDifference = 32;


        //public void test(String pfad)
        //{
        //    Console.Write(pfad);
        //    string[] fileEntries = Directory.GetFiles(@pfad, "*.xml");
        //    Console.WriteLine(fileEntries.Length);
        //}

        public List<string> xmleinlesen(String xmlfilename)   //XML-Parser (datenbank, ip, benutzer, passwort, gewaelterPfad);
        {
            //OcrWord myword = new OcrWord();
            int[] BuchstinWort = new int[80];
            list.Clear();
            //System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            //sw.Start();

            if (!System.IO.Directory.Exists(@"C:\directory"))
            {
                Directory.CreateDirectory(@"C:\directory");
            }
            string targetpath = @"C:\directory\targetfile.xml";
            File.Copy(xmlfilename, targetpath, true);                    //copy the file from xmlfilename to the targetpath
            string[] fileEntries = Directory.GetFiles(@"C:\directory\", "*.xml");




            //foreach (string a in fileEntries)
            //{
            //    Console.WriteLine(a );
            //}
            //Console.WriteLine("Dateien eingelesen: " + fileEntries.Length);
            foreach (string fileName in fileEntries)
            {
                String[] stringArray = File.ReadAllLines(fileName);    // Ausgewählte Datei in ein Textfeld auslesen und schliessen...
                int[,] intFeld = new int[stringArray.Length, 4]; 
                int y, posleft, postop, posright, posbottom, poswortende, posgroesser, poskleiner, wortanzahl = 0, wortendeanzahl = 0, language;
                String einwort, bruchstuecke;                                 // String für eine erweiterete Zeile
                const string quote = "\"";
                for (int x = 0; x < stringArray.Length; x++)
                {
                    OcrWord myword = new OcrWord();
                    if (stringArray[x].Contains("<wd"))                             //enthält eine Zeile den Wortanfang
                    {
                        einwort = String.Copy(stringArray[x]);                         //wenn ja wird sie umkopiert
                        wortanzahl = wortanzahl + 1;
                        y = x;
                        while (!(stringArray[y].Contains("/wd>")))                      //und so lange ergänzt bis das Wortende auch enthalten ist
                        {
                            y = y + 1;
                            einwort = String.Concat(einwort, stringArray[y]);           // hier werden die Zeilen verbunden
                        }
                        if (einwort.Contains("/wd>")) wortendeanzahl = wortendeanzahl + 1;
                        // Weise den aktuellen Wert dem int Feld hinzu 
                        posleft = einwort.IndexOf("l="); einwort = einwort.Remove(0, posleft + 3); posleft = einwort.IndexOf(quote);intFeld[x, 0] = Convert.ToInt32(einwort.Substring(0, posleft)) *300 / 1440;                 
                        postop = einwort.IndexOf("t="); einwort = einwort.Remove(0, postop + 3); postop = einwort.IndexOf(quote); intFeld[x, 1] = Convert.ToInt32(einwort.Substring(0, postop)) *300 / 1440;
                        posright = einwort.IndexOf("r="); einwort = einwort.Remove(0, posright + 3); posright = einwort.IndexOf(quote); intFeld[x, 2] = Convert.ToInt32(einwort.Substring(0, posright)) *300 / 1440;
                        posbottom = einwort.IndexOf("b="); einwort = einwort.Remove(0, posbottom + 3); posbottom = einwort.IndexOf(quote); intFeld[x, 3] = Convert.ToInt32(einwort.Substring(0, posbottom)) *300 / 1440;
                        
                        if (einwort.Contains("<run"))
                        {
                            language = einwort.IndexOf("fontFace=");
                            einwort = einwort.Remove(0, language + 10);
                            language = einwort.IndexOf(quote);
                            myword.fontFace = einwort.Substring(0, language);
                        }
                        Rectangle wordRect = new Rectangle(0, 0, 0, 0);
                        wordRect.X = intFeld[x, 0];           //   l
                        wordRect.Y = intFeld[x, 1];           //   t
                        wordRect.Width = intFeld[x, 2] - intFeld[x, 0];    //r-l
                        wordRect.Height = intFeld[x, 3] - intFeld[x, 1];   //b-t

                        myword.position = wordRect;

                        string[] abc = new string[6];
                        abc[0] = intFeld[x, 0].ToString();                           // Rechteck //kann weg
                        abc[1] = intFeld[x, 1].ToString();
                        abc[2] = intFeld[x, 2].ToString();
                        abc[3] = intFeld[x, 3].ToString();                             // bis hier

                        //myword.fontSize = Convert.ToInt32(postop) - Convert.ToInt32(posbottom);
                        bruchstuecke = "";
                        poswortende = einwort.IndexOf("/wd>");
                        do
                        {
                            posgroesser = einwort.IndexOf(">");                         // Die Positionen von > wird bestimmt
                            einwort = einwort.Remove(0, posgroesser);                  // und gelöscht
                            posgroesser = einwort.IndexOf(">");                       // Die Positionen von > wird bestimmt
                            poskleiner = einwort.IndexOf("<");                       // Die Positionen von < wird bestimmt
                            if (poskleiner > 0)
                            {
                                bruchstuecke = String.Concat(bruchstuecke, einwort.Substring(posgroesser + 1, poskleiner - 1));
                                einwort = einwort.Remove(0, poskleiner);                // und gelöscht
                            }
                        }
                        while ((poskleiner - posgroesser > 0));

                        //myword.text = bruchstuecke;                       //abc[4]
                        abc[4] = bruchstuecke;                         
                        myword.fileName = fileName;                       // abc[5]
                        abc[5] = fileName;           

                //  list.Add(abc);
                // ocrList.Add(myword);
                       //  Console.WriteLine("Dateiname von Wort : " + myword.fileName);
                       // Console.WriteLine("LÄNGE OCRlIST: " + ocrList.Count());
                // objekte.Add(myword);
                    //foreach (string[] abcd in list)
                    //{
                        string[] abcd=abc;
                        String zeichen;
                        int pos = -1;
                        if (abcd[4].Length >= 80)
                        {
                            //Console.WriteLine(abcd[4]);                              // auf 80 abschneiden
                            abcd[4] = abcd[4].Substring(0, 80);
                        }
                        for (int a = 0; a < abcd[4].Length; a++)
                        {
                            zeichen = abcd[4].Substring(a, 1);
                            pos = ErlaubteZeichen.IndexOf(zeichen);                      // Die Positionen von zeichen wird bestimmt
                            if (pos < 0)
                            {
                                abcd[4] = abcd[4].Replace(zeichen, ErlaubteZeichen.Substring(ErlaubteZeichen.Length - 1, 1));
                                pos = ErlaubteZeichen.Length - 1;        //unerlaubte Zeichen durch * ersetzen
                                // Console.WriteLine(ErlaubteZeichen.Substring(ErlaubteZeichen.Length - 1, 1));           // auf 80 abschneiden
                            }
                            BuchstinWort[a] = pos;
                        }
                        myword.text = abcd[4];
                        Console.WriteLine(abcd[4] + " " + myword.text);
                        string toxml = abcd[4];
                        mlist.Add(toxml);
                        ocrList.Add(myword);  
                             //i++; //Zeilennummer omnipage16ocr erhöhen
                    }     
                          // Console.WriteLine(abcd[4] + " " + myword.text);
                          //  Console.WriteLine(/*abcd[0] + " " + abcd[1] +" " +abcd[2] +" "+ abcd[3] + " " +*/ abcd[4]);         
                }
            }

            //int i = 0;      // Convert.ToInt32(row);    //Zeilennummer omnipage16ocr
            //int j = 0;     // Convert.ToInt32(row2);   //Zeilennummer tripletword16

            TexteZusammenfassen(ocrList); 
        
            //sw.Stop();       // Console.WriteLine("Millisekundenen: " + sw.ElapsedMilliseconds);
            //sw.Reset();
            // Console.WriteLine("ocrlist.position     "+ocrList[0].position);
            return mlist;
        }

        public List<string> TexteZusammenfassen(List<OcrWord> ocrList)//(OcrWord myWord) //ocr List muß übergeben werden nicht ´wotrd..
        {
            OcrWord myWord;
            // Console.WriteLine(ocrList[ocrList.Count-1].fileName + "mnnmnmn" + ocrList[1].fileName);
            combinedTextList.Clear(); // löscht die Textliste mit zusammengefügten Wörtern
                                     // if (myImageProcessing.ocrlist.Count == 0) return;
            Rectangle rectOld = ocrList[0].position;

            string txtOld = ocrList[0].text;
            Rectangle rectSentence = ocrList[0].position;
            string sentence = txtOld;

            // ocrList verarbeiten
            for (int i = 1; i < ocrList.Count; i++)
            {
                myWord = ocrList[i];
                // Console.WriteLine(myWord.text);

                // für die weiteren einträge wird dann geschaut, ob sie den
                // vorigen ergänzen (d.h. rechts daneben sind)
                // wenn ja, dann den vorigen vergrößern
               if (((myWord.topLeft.X - rectSentence.Right) >= 0) && ((myWord.topLeft.X - rectSentence.Right) <= maxXDistance) && (Math.Abs(myWord.bottomRight.Y - rectSentence.Bottom) <= maxYDifference))
                {
                    Rectangle tempRect = rectSentence;
                    tempRect.X = rectSentence.Left;
                    tempRect.Y = Math.Min(myWord.topLeft.Y, rectSentence.Top);
                    tempRect.Width = (myWord.bottomRight.X - rectSentence.X);
                    tempRect.Height = (Math.Max(myWord.bottomRight.Y, rectSentence.Bottom) - tempRect.Y);
                    sentence = sentence + " " + myWord.text;
                    //Console.WriteLine(sentence);
                    rectSentence = tempRect;
                }
                else
                // sonst neues rechteck aufmachen, und altes in combinedTextList schreiben:
                { 
                    llist.Add(sentence);
                    combinedTextList.Add(new OcrWord(rectSentence, sentence));
                    rectSentence = myWord.position;                  
                    sentence = myWord.text;
                }
            }
            //den letzten nicht vergessen:
            combinedTextList.Add(new OcrWord(rectSentence, sentence));
            Console.WriteLine(rectSentence + " " + sentence);
            Console.ReadLine();
            llist.Add(sentence);
            return llist;
        }
    
    }

}
