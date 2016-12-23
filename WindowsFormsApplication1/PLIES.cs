using System;                     // invoking namespace
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;                   // it is needed when read and write text in to files
using System.Collections;
using System.Threading;            // invoking thread
using System.Text.RegularExpressions;
using System.Xml;
using OpenCvSharp;
using System.Drawing.Drawing2D;
using StandAPHerbWebGenesisServices;
using System.Reflection;
using Newtonsoft.Json.Linq;
using System.Net;


namespace WindowsFormsApplication1
{
    
    public partial class PLIES : Form 
    {
        private static StandAPHerbService service = new StandAPHerbService();
        public static PLIES pCurrentwin = null;
        image form2=new image();
        Login login;
        LevenshteinDistance myLevenshteinDistance;
        Verarbeitungen myVerarbeitungen;
        Verarbeitung1 myVerarbeitung;
       
        image_rectangule_drawing drawingrectangular;
        Thread t; 
        public int controlnumber=0,j =1;
        public string[] fileEntries,fileEntries1,fileEntries2;
        public bool n = false;
        public bool Switch = false;
        public string loadiamgepath = "";
        public string ImagefilePath;
        public string XMLfilePath;
        public string noteinfo;
        
        public PLIES()
        {
            pCurrentwin = this;
            Form.CheckForIllegalCrossThreadCalls = false; //it can't be used in many threads
            InitializeComponent();
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            t = new Thread(new ThreadStart(RunImage));    
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            t.Abort();  // end the thread
        }

        //private void institution_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (a11.SelectedItem.Equals("Herbarium BAK"))
        //    {
        //        a13.Items.Clear();
        //        a13.Items.AddRange(new object[] { "BAK" });
        //        a13.Text = "BAK";
        //    }
        //    else if (a11.SelectedItem.Equals("Herbarium BRNU"))
        //    {
        //        a13.Items.Clear();
        //        a13.Items.AddRange(new object[] { "BRNU" });
        //        a13.Text = "BRNU";
        //    }
        //    else if (a11.SelectedItem.Equals("Herbarium CHER"))
        //    {
        //        a13.Items.Clear();
        //        a13.Items.AddRange(new object[] { "CHER" });
        //        a13.Text = "CHER";
        //    }
        //    else if (a11.SelectedItem.Equals("Herbarium GAT"))
        //    {
        //        a13.Items.Clear();
        //        a13.Items.AddRange(new object[] { "GAT" });
        //        a13.Text = "GAT";
        //    }
        //    else if (a11.SelectedItem.Equals("Herbarium GJO"))
        //    {
        //        a13.Items.Clear();
        //        a13.Items.AddRange(new object[] { "GJO" });
        //        a13.Text = "GJO";
        //    }
        //    else if (a11.SelectedItem.Equals("Herbarium GZU"))
        //    {
        //        a13.Items.Clear();
        //        a13.Items.AddRange(new object[] { "GZU","GZU ethnobotanische Kollektion","GZU Holz-Kollektion","GZU karpologische Kollektion,GZU StudienHerbar",
        //            "GZU-Arbesser","GZU-Brunner","GZU-Conrath","GZU-Czegka","GZU-Degener","GZU-Dolenz","GZU-Eberstaller","GZU-Ecklon & Zeyher","GZU-Eggler","GZU-Ettingshausen",
        //            "GZU-Evers","GZU-Fritsch","GZU-Hachtmann","GZU-Heider","GZU-Heske","GZU-Höpflinger","GZU-Hoppe","GZU-Huber & Dietl","GZU-Husak","GZU-Karl","GZU-Kerner",
        //            "GZU-Krašan","GZU-Lemperg","GZU-Maurer","GZU-Melzer","GZU-Mulley","GZU-Nees ab Esenbeck","GZU-Nemetz","GZU-Nevole","GZU-Palla","GZU-Pernhoffer","GZU-Petrak",
        //            "GZU-Pilhatsch","GZU-Pittoni","GZU-Poelt","GZU-Rechinger","GZU-Rössler","GZU-Rosthorn","GZU-Salzmann","GZU-Schaeftlein","GZU-Schmarda","GZU-Schulz",
        //            "GZU-Schwimmer","GZU-Starmühler","GZU-Stippl","GZU-Stolba","GZU-Teppner","GZU-Thwaites & Wallich","GZU-Troyer","GZU-Untchj","GZU-Vončina","GZU-Widder",
        //            "GZU-Wight","GZU-Witasek","GZU-Woynar","GZU-Zenker" });
        //    }
        //    else if (a11.SelectedItem.Equals("Herbarium HAL"))
        //    {
        //        a13.Items.Clear();
        //        a13.Items.AddRange(new object[] { "HAL" });
        //        a13.Text = "HAL";
        //    }
        //    else if (a11.SelectedItem.Equals("Herbarium Drogistenmuseum Österreichs"))
        //    {
        //        a13.Items.Clear();
        //        a13.Items.AddRange(new object[] { "Herb DrogMus AT" });
        //        a13.Text = "AT";
        //    }
        //    else if (a11.SelectedItem.Equals("Herbarium Haussknecht JE"))
        //    {
        //        a13.Items.Clear();
        //        a13.Items.AddRange(new object[] { "JE" });
        //        a13.Text = "JE";
        //    }
        //    else if (a11.SelectedItem.Equals("Herbarium HERZ"))
        //    {
        //        a13.Items.Clear();
        //        a13.Items.AddRange(new object[] { "HERZ" });
        //        a13.Text = "HERZ";
        //    }
        //    else if (a11.SelectedItem.Equals("Herbarium Institute of Ecology of the Carpathians"))
        //    {
        //        a13.Items.Clear();
        //        a13.Items.AddRange(new object[] { "LWKS" });
        //        a13.Text = "LWKS";
        //    }
        //    else if (a11.SelectedItem.Equals("Herbarium KFTA"))
        //    {
        //        a13.Items.Clear();
        //        a13.Items.AddRange(new object[] { "KFTA" });
        //        a13.Text = "KFTA";
        //    }
        //    else if (a11.SelectedItem.Equals("Herbarium KUFS"))
        //    {
        //        a13.Items.Clear();
        //        a13.Items.AddRange(new object[] { "KUFS" });
        //        a13.Text = "KUFS";
        //    }
        //    else if (a11.SelectedItem.Equals("Herbarium LAGU"))
        //    {
        //        a13.Items.Clear();
        //        a13.Items.AddRange(new object[] { "LAGU" });
        //        a13.Text = "LAGU";
        //    }
        //    else if (a11.SelectedItem.Equals("Herbarium LECB"))
        //    {
        //        a13.Items.Clear();
        //        a13.Items.AddRange(new object[] { "LECB" });
        //        a13.Text = "LECB";
        //    }
        //    else if (a11.SelectedItem.Equals("Herbarium LW"))
        //    {
        //        a13.Items.Clear();
        //        a13.Items.AddRange(new object[] { "LW" });
        //        a13.Text = "LW";
        //    }
        //    else if (a11.SelectedItem.Equals("Herbarium LWS"))
        //    {
        //        a13.Items.Clear();
        //        a13.Items.AddRange(new object[] { "LWS" });
        //        a13.Text = "LWS";
        //    }
        //    else if (a11.SelectedItem.Equals("Herbarium LZ"))
        //    {
        //        a13.Items.Clear();
        //        a13.Items.AddRange(new object[] { "LZ" });
        //        a13.Text = "LZ";
        //    }
        //    else if (a11.SelectedItem.Equals("Herbarium MJG"))
        //    {
        //        a13.Items.Clear();
        //        a13.Items.AddRange(new object[] { "MJG", "MJG-Fungi", "MJG-Herbarium Garganicum", "MJG-Rheinland Pfalz" });
        //    }
        //    else if (a11.SelectedItem.Equals("Herbarium Peter Pilsl"))
        //    {
        //        a13.Items.Clear();
        //        a13.Items.AddRange(new object[] { "Herb Pilsl Peter" });
        //        a13.Text = "Herb Pilsl Peter";
        //    }
        //    else if (a11.SelectedItem.Equals("Herbarium PRC"))
        //    {
        //        a13.Items.Clear();
        //        a13.Items.AddRange(new object[] { "PRC" });
        //        a13.Text = "PRC";
        //    }
        //    else if (a11.SelectedItem.Equals("Herbarium TGU"))
        //    {
        //        a13.Items.Clear();
        //        a13.Items.AddRange(new object[] { "TGU" });
        //        a13.Text = "TGU";
        //    }
        //    else if (a11.SelectedItem.Equals("Herbarium University Tunceli"))
        //    {
        //        a13.Items.Clear();
        //        a13.Items.AddRange(new object[] { "HTunc" });
        //        a13.Text = "HTunc";
        //    }
        //    else if (a11.SelectedItem.Equals("Herbarium W"))
        //    {
        //        a13.Items.Clear();
        //        a13.Items.AddRange(new object[] { "W","W Krypto","W Krypto-Grunow","W Krypto-Zahlbruckner","W-Bauer","W-Boos","W-Buchenau","W-E. Khek","W-Endlicher",
        //             "W-Erzherzog Rainer","W-F. Wimmer","W-Fenzl","W-Hackel","W-Herb.bras.","W-Hirth","W-Host","W-Jacq.","W-Jacq. fil.","W-Neilreich","W-Portenschlag",
        //             "W-Putterlick","W-Rchb.","W-Rchb.Orch.","W-Ronniger","W-Stella mat.","W-Tratt.","W-Wołoszczak","W-Wulfen","W-ZooBot" });
        //    }
        //    else if (a11.SelectedItem.Equals("Herbarium WU"))
        //    {
        //        a13.Items.Clear();
        //        a13.Items.AddRange(new object[] { "WU","WU-Algae","WU-Bryophyta-Hepaticae","WU-Bryophyta-Musci","WU-Carpologica","WU-Dörfler","WU-Fungi-Generale",
        //              "WU-Halácsy-Europaeum","WU-Halácsy-Graecum","WU-HBV","WU-Keck","WU-Kerner","WU-Lichenes","WU-Liquor","WU-Melk","WU-Mykologicum","WU-Pteridophyta",
        //              "WU-Schönbeck"});
        //    }
        //    else if (a11.SelectedItem.Equals("Test Institution"))
        //    {
        //        a13.Items.Clear();
        //        a13.Items.AddRange(new object[] { "TEST" });
        //        a13.Text = "TEST";
        //    }
        //    else if (a11.SelectedItem.Equals("Herbarium LZ"))
        //    {
        //        a13.Items.Clear();
        //        a13.Items.AddRange(new object[] { "LZ" });
        //        a13.Text = "LZ";
        //    }
        //}
        //private void continent_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (continent.SelectedItem.Equals("africa"))
        //    {
        //        region.Items.Clear();
        //        region.Items.AddRange(new object[] { "eastern africa", "northern africa", "southern africa", "western africa", "middle africa" });
        //    }
        //    else if (continent.SelectedItem.Equals("americas"))
        //    {
        //        region.Items.Clear();
        //        region.Items.AddRange(new object[] { "south america", "noth america", "central america", "caribbean" });
        //    }
        //    else if (continent.SelectedItem.Equals("asia"))
        //    {
        //        region.Items.Clear();
        //        region.Items.AddRange(new object[] { "middle east", "asia" });
        //    }
        //    else if (continent.SelectedItem.Equals("europe"))
        //    {
        //        region.Items.Clear();
        //        region.Items.AddRange(new object[] { "europe" });
        //        region.Text = "europe";
        //    }
        //    else if (continent.SelectedItem.Equals("oceania"))
        //    {
        //        region.Items.Clear();
        //        region.Items.AddRange(new object[] { "oceania" });
        //        region.Text = "oceania";
        //    }
        //}
        //private void region_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (region.SelectedItem.Equals("eastern africa"))
        //    {
        //        country.Items.Clear();
        //        country.Items.AddRange(new object[] { "Burundi", "Comoros", "Djibouti", "Eritrea", "Ethiopia", "Glorioso islands", "Kenya", "La Réunion"," Madagascar","Malawi",
        //                        "Mauritius","Mayotte","Mozambique","Réunion","Rwanda","Seychelles","Somalia","Tanzania","Uganda","Zambia","Zimbabwe"});
        //    }
        //    else if (region.SelectedItem.Equals("middle africa"))
        //    {
        //        country.Items.Clear();
        //        country.Items.AddRange(new object[] { "Angola","Cameroon","Central African Republic","Chad","Congo Democratic Republic","Congo People’s Republic",
        //            "Equatorial Guinea","Gabon","São Tomé and Príncipe" });
        //    }
        //    else if (region.SelectedItem.Equals("northern africa"))
        //    {
        //        country.Items.Clear();
        //        country.Items.AddRange(new object[] { "Algeria", "Egypt", "Libya", "Morocco", "Sudan", "Tunisia", "Western Sahara" });
        //    }
        //    else if (region.SelectedItem.Equals("southern africa"))
        //    {
        //        country.Items.Clear();
        //        country.Items.AddRange(new object[]{"Botswana","Bouvet Island","Lesotho","Namibia","Saint Helena","South Africa",
        //            "South Georgia and South Sandwich Islands","Swaziland"});
        //    }
        //    else if (region.SelectedItem.Equals("western africa"))
        //    {
        //        country.Items.Clear();
        //        country.Items.AddRange(new object[]{"Benin","Burkina Faso","Cape Verde","Gambia","Ghana","Guinea",
        //            "Guinea-Bissau","Ivory Coast","Liberia","Mali","Mauritania","Niger","Nigeria","Senegal","Sierra Leone","Togo"});
        //    }
        //    else if (region.SelectedItem.Equals("caribbean"))
        //    {
        //        country.Items.Clear();
        //        country.Items.AddRange(new object[]{"Anguilla","Antigua and Barbuda","Aruba","Bahamas","Barbados","Bermuda","British Virgin Islands",
        //              "Cayman Island","Cuba","Dominica","Dominica Republic","Grenada","Guadeloupe","Haiti","Jamaica","Martinique","Montserrat",
        //              "Netherlands Antilles","Puerto Rico","Saint Kitts and Nevis","Saint Lucia","Saint Vincent and the Grenadines","Trinidad and Tobago",
        //              "Turks and Caicos Islands","United States Virgin Islands"});
        //    }
        //    else if (region.SelectedItem.Equals("north america"))
        //    {
        //        country.Items.Clear();
        //        country.Items.AddRange(new object[] { "Canada", "Greenland", "Saint Pierre and Miquelon", "USA" });
        //    }
        //    else if (region.SelectedItem.Equals("south america"))
        //    {
        //        country.Items.Clear();
        //        country.Items.AddRange(new object[]{"Argentina","Bolivia","Brazil","Chile","Colombia","Ecuador","Falkland Islands","French Guiana","Guyana",
        //             "Paraguay","Peru","Suriname","Uruguay","Venezuela"});
        //    }
        //    else if (region.SelectedItem.Equals("central america"))
        //    {
        //        country.Items.Clear();
        //        country.Items.AddRange(new object[] { "Belize", "Costa Rica", "El Salvador", "Guatemala", "Honduras", "Mexico", "Nicaragua", "Panama" });
        //    }
        //    else if (region.SelectedItem.Equals("asia"))
        //    {
        //        country.Items.Clear();
        //        country.Items.AddRange(new object[]{"Afghanistan","Armenia","Azerbaijan","Bahrain","Bangladesh","Bhutan","Brunei","Cambodia","China","Cyprus","Georgia",
        //             "India","Indonesia","Iran","Iraq","Israel","Japan","Jordan","Kazakhstan","Korea, North","Korea, South","Kuwait","Kyrgyzstan","Laos","Lebanon",
        //             "Malaysia","Maldives","Mongolia","Myanmar","Nepal","Oman","Pakistan","Palestine","Philippines","Qatar","Russia","Saudi Arabia","Singapore","Sri Lanka",
        //             "Syria","Tajikistan","Thailand","Timor-Leste/East Timor","Turkey","Turkmenistan","United Arab Emirates","Uzbekistan","Vietnam / Viet Nam","Yemen"});
        //    }
        //    else if (region.SelectedItem.Equals("europe"))
        //    {
        //        country.Items.Clear();
        //        country.Items.AddRange(new object[]{"Albania","Andorra","Armenia","Austria","Azerbaijan","Belarus","Belgium","Bosnia and Herzegovina","Bulgaria","Croatia",
        //              "Cyprus","Czech Republic","Denmark","Estonia","Finland","France","Georgia","Germany","Greece","Hungary","Iceland","Italy","Kazakhstan","Latvia",
        //              "Liechtenstein","Lithuania","Luxembourg","Macedonia","Malta","Moldova","Monaco","Montenegro","Netherlands","Norway","Poland","Portugal","Romania",
        //              "Russia[e]","San Marino","Serbia","Slovakia","Slovenia","Spain","Sweden","Switzerland","Turkey","Ukraine","United Kingdom","Vatican City"});
        //    }
        //    else if (region.SelectedItem.Equals("oceania"))
        //    {
        //        country.Items.Clear();
        //        country.Items.AddRange(new object[]{"America Samoa","Ashmore and Cartier Islands","Australia","Christmas Island","Cook Islands","Fiji","French Polynesia",
        //               "Guam","Heard and McDonald Islands","Kiribati","Marshall Islands","Micronesia, Federated States of","Nauru","New Caledonia","New Zealand","Niue",
        //               "Northern Mariana Islands","Palau","Papua New Guinea","Pitcairn Islands","Samoa","Solomon Islands","Tokelau Islands","Tonga","Tuvalu","Vanuatu",
        //               "Wallis and Futuna"});
        //    }
        //}
        private void country_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (a18.SelectedItem.Equals("Burundi"))
            {
                a19.Items.Clear();
                a19.Items.AddRange(new object[] { "Bubanza", "Bujumbura", "Bururi", "Cankuzo", "Cibitoke", "Gitega", "Karuzi", "Kayanza", "Kirundo", "Makamba", "Muramvya", "Muyinga", "Mwaro", "Ngozi", "Rutana", "Ruyigi" });
            }
        }
        private void state_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
                          
        public void RunImage()    // definied a methord for invoking the thread 
        {
           
            try
            {
                fileEntries = Directory.GetFiles(ImagefilePath, "*.bmp");
                
            }
                catch (Exception)
            {
                MessageBox.Show("please load a picture");
                return;
            }
            
            //fileEntries1 = Directory.GetFiles(@"C:\Users\Cailin\Desktop\Project\Bilder\", "*.txt");
            try { fileEntries2 = Directory.GetFiles(XMLfilePath, "*.xml"); }
            catch (Exception)
            {
                MessageBox.Show("please load XML file");
                return;
            }
            int i;
            for (i = 0; i < fileEntries.Length; i++,controlnumber++)
            {
                if (i != controlnumber)
                    i = controlnumber;
                if (controlnumber < 0)
                {
                    controlnumber = 0;
                }
                a5.Text = Path.GetFileName(fileEntries[controlnumber]);
                FileStream pFileStream = new FileStream(fileEntries[controlnumber], FileMode.Open, FileAccess.Read);
                pictureBox1.Image = Image.FromStream(pFileStream);
                form2.pictureBox1.Image = pictureBox1.Image;
                pFileStream.Close();
                pFileStream.Dispose();
                //String sr = @fileEntries1[controlnumber];
                //StreamReader str = new StreamReader(sr, Encoding.GetEncoding("gb2312")); //preventing the garbled when reading the text string.      
                myVerarbeitung = new Verarbeitung1();
                String xmlfilename= fileEntries2[controlnumber];
                myVerarbeitung.xmleinlesen(xmlfilename);

                //xml.Text = null;
                //foreach (string element in myVerarbeitung.mlist)
                //{
                //    xml.Text += element + "\r\n";
                //}         

                textBox2.Text = null;
                foreach (string element in myVerarbeitung.llist)
                {
                    textBox2.Text += element + "\r\n";
                }

                //Search(textBox1);
                controlnumber = i;
                foreach (Control ctrl in panel1.Controls)     // to highlight the spare blanks
                {
                    if (ctrl is TextBox || ctrl is ComboBox)
                    {
                        if (ctrl.Text == "")
                        {
                            ctrl.BackColor = Color.LightYellow;
                            ctrl.BackColor = Color.LightYellow;
                        }
                        else
                        {
                            ctrl.BackColor = Color.White;
                            ctrl.BackColor = Color.White;
                        }
                    }
                }
                try
                {
                    Search(textBox2);
                }
                catch (Exception)
                { return; }
                Thread.Sleep(2000);   // thread have a break for (2s) 
            }
        }
        //private void Save_Click_1(object sender, EventArgs e)
        //{
        //    pCurrentwin = this;
        //    myVerarbeitungen = new Verarbeitungen();    
        //    XmlDocument doc = myVerarbeitungen.xml();
        //    //Stream myStream;
        //    //SaveFileDialog saveFileDialog1 = new SaveFileDialog();

        //    //saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
        //    //saveFileDialog1.FilterIndex = 2;
        //    //saveFileDialog1.RestoreDirectory = true;

        //    //if (saveFileDialog1.ShowDialog() == DialogResult.OK)
        //    //{
        //    //    if ((myStream = saveFileDialog1.OpenFile()) != null)
        //    //    {
        //    //        // Code to write the stream goes here.
        //    //        myStream.Close();
        //    //    }
        //    //}
        //}     
        private void button3_Click(object sender, EventArgs e)
        {
            myVerarbeitungen = new Verarbeitungen();
            myVerarbeitungen.Lenvenstein();
        }  //check the text
        private void Barcode_MouseClick(object sender, MouseEventArgs e)
        {
            int i = this.a3.SelectionStart;
            string s = this.a3.Text;
            if (textBox2.SelectedText != "")
            {
                textBox2.Select();
                string ss = textBox2.SelectedText;
                s = s.Insert(i, ss);
                a3.Text = s;
                textBox2.Select(textBox2.TextLength, 0);
            }
        }

        private void Accession_MouseClick(object sender, MouseEventArgs e)
        {
            int i = this.a4.SelectionStart;
            string s = this.a4.Text;
            if (textBox2.SelectedText != "")
            {
                textBox2.Select();
                string ss = textBox2.SelectedText;
                s = s.Insert(i, ss);
                a4.Text = s;
                textBox2.Select(textBox2.TextLength, 0);
            }

        }

        private void ImageNum_MouseClick(object sender, MouseEventArgs e)
        {
            int i = this.a5.SelectionStart;
            string s = this.a5.Text;
            if (textBox2.SelectedText != "")
            {
                textBox2.Select();
                string ss = textBox2.SelectedText;
                s = s.Insert(i, ss);
                a5.Text = s;
                textBox2.Select(textBox2.TextLength, 0);
            }

        }
        private void collector_MouseClick(object sender, MouseEventArgs e)
        {
            int i = this.a6.SelectionStart;
            string s = this.a6.Text;
            if (textBox2.SelectedText != "")
            {
                textBox2.Select();
                string ss = textBox2.SelectedText;
                s = s.Insert(i, ss);
                a6.Text = s;
                textBox2.Select(textBox2.TextLength, 0);
            }
        }
        private void CollNum_MouseClick(object sender, MouseEventArgs e)
        {
            int i = this.a7.SelectionStart;
            string s = this.a7.Text;
            if (textBox2.SelectedText != "")
            {
                textBox2.Select();
                string ss = textBox2.SelectedText;
                s = s.Insert(i, ss);
                a7.Text = s;
                textBox2.Select(textBox2.TextLength, 0);
            }
        }
        private void Locality_MouseClick(object sender, MouseEventArgs e)
        {

            int i = this.a8.SelectionStart;
            string s = this.a8.Text;
            if (textBox2.SelectedText != "")
            {
                textBox2.Select();
                string ss = textBox2.SelectedText;
                s = s.Insert(i, ss);
                a8.Text = s;
                textBox2.Select(textBox2.TextLength, 0);
            }
        }

        private void OtherColl_MouseClick(object sender, MouseEventArgs e)
        {
            int i = this.a9.SelectionStart;
            string s = this.a9.Text;
            if (textBox2.SelectedText != "")
            {
                textBox2.Select();
                string ss = textBox2.SelectedText;
                s = s.Insert(i, ss);
                a9.Text = s;
                textBox2.Select(textBox2.TextLength, 0);
            }

        }

        private void Family_MouseClick(object sender, MouseEventArgs e)
        {
            int i = this.a11.SelectionStart;
            string s = this.a11.Text;
            if (textBox2.SelectedText != "")
            {
                textBox2.Select();
                string ss = textBox2.SelectedText;
                s = s.Insert(i, ss);
                a11.Text = s;
                this.a11.DroppedDown = true;
                textBox2.Select(textBox2.TextLength, 0);
            }

        }

        private void Genus_MouseClick(object sender, MouseEventArgs e)
        {
            int i = this.a12.SelectionStart;
            string s = this.a12.Text;
            if (textBox2.SelectedText != "")
            {
                textBox2.Select();
                string ss = textBox2.SelectedText;
                s = s.Insert(i, ss);
                a12.Text = s;
                this.a11.DroppedDown = true;
                textBox2.Select(textBox2.TextLength, 0);
            }

        }
        private void Specise_MouseClick(object sender, MouseEventArgs e)
        {
            int i = this.a13.SelectionStart;
            string s = this.a13.Text;
            if (textBox2.SelectedText != "")
            {
                textBox2.Select();
                string ss = textBox2.SelectedText;
                s = s.Insert(i, ss);
                a13.Text =s;
                this.a13.DroppedDown = true;
                textBox2.Select(textBox2.TextLength, 0);
            }
        }

        private void SupSp_MouseClick(object sender, MouseEventArgs e)
        {
            int i = this.a14.SelectionStart;
            string s = this.a14.Text;
            if (textBox2.SelectedText != "")
            {
                textBox2.Select();
                string ss = textBox2.SelectedText;
                s = s.Insert(i, ss);
                a14.Text =s;
                textBox2.Select(textBox2.TextLength, 0);
            }
        }
        private void Sceintificname_MouseClick(object sender, MouseEventArgs e)
        {
            int i = this.a15.SelectionStart;
            string s = this.a15.Text;
            if (textBox2.SelectedText != "")
            {
                textBox2.Select();
                string ss = textBox2.SelectedText;
                s = s.Insert(i, ss);
                a15.Text = s;
                textBox2.Select(textBox2.TextLength, 0);
            }

        }
        private void Determiner_MouseClick(object sender, MouseEventArgs e)
        {
            int i = this.a16.SelectionStart;
            string s = this.a16.Text;
            if (textBox2.SelectedText != "")
            {
                textBox2.Select();
                string ss = textBox2.SelectedText;
                s = s.Insert(i, ss);
                a16.Text = s;
                textBox2.Select(textBox2.TextLength, 0);
            }

        }
        private void DetDate_MouseClick(object sender, MouseEventArgs e)
        {
            int i = this.a17.SelectionStart;
            string s = this.a17.Text;
            if (textBox2.SelectedText != "")
            {
                textBox2.Select();
                string ss = textBox2.SelectedText;
                s = s.Insert(i, ss);
                a17.Text = s;
                textBox2.Select(textBox2.TextLength, 0);
            }

        }
        private void country_MouseClick(object sender, MouseEventArgs e)
        {
            int i = this.a18.SelectionStart;
            string s = this.a18.Text;
            if (textBox2.SelectedText != "")
            {
                textBox2.Select();
                string ss = textBox2.SelectedText;
                s = s.Insert(i, ss);
                a18.Text = s;
                this.a18.DroppedDown = true;
                textBox2.Select(textBox2.TextLength, 0);
            }
        }
        private void state_MouseClick(object sender, MouseEventArgs e)
        {
            int i = this.a19.SelectionStart;
            string s = this.a19.Text;
            if (textBox2.SelectedText != "")
            {
                textBox2.Select();
                string ss = textBox2.SelectedText;
                s = s.Insert(i, ss);
                a19.Text =s;
                this.a19.DroppedDown = true;
                textBox2.Select(textBox2.TextLength, 0);
            }
        }
        private void Hebitat_MouseClick(object sender, MouseEventArgs e)
        {
            int i = this.a20.SelectionStart;
            string s = this.a20.Text;
            if (textBox2.SelectedText != "")
            {
                textBox2.Select();
                string ss = textBox2.SelectedText;
                s = s.Insert(i, ss);
                a20.Text = s;
                textBox2.Select(textBox2.TextLength, 0);
            }
        }
        private void Scripts_MouseClick(object sender, MouseEventArgs e)
        {

            int i = this.a21.SelectionStart;
            string s = this.a21.Text;
            if (textBox2.SelectedText != "")
            {
                textBox2.Select();
                string ss = textBox2.SelectedText;
                s = s.Insert(i, ss);
                a21.Text = s;
                textBox2.Select(textBox2.TextLength, 0);
            }

        }
        private void Notes_MouseClick(object sender, MouseEventArgs e)
        {

            int i = this.a22.SelectionStart;
            string s = this.a22.Text;
            if (textBox2.SelectedText != "")
            {
                textBox2.Select();
                string ss = textBox2.SelectedText;
                s = s.Insert(i, ss);
                a22.Text = s;
                textBox2.Select(textBox2.TextLength, 0);
            }

        }
        private void UnioIT_MouseClick(object sender, MouseEventArgs e)
        {
            int i = this.a23.SelectionStart;
            string s = this.a23.Text;
            if (textBox2.SelectedText != "")
            {
                textBox2.Select();
                string ss = textBox2.SelectedText;
                s = s.Insert(i, ss);
                a23.Text = s;
                textBox2.Select(textBox2.TextLength, 0);
            }

        }

        private void TopKD_MouseClick(object sender, MouseEventArgs e)
        {

            int i = this.a24.SelectionStart;
            string s = this.a24.Text;
            if (textBox2.SelectedText != "")
            {
                textBox2.Select();
                string ss = textBox2.SelectedText;
                s = s.Insert(i, ss);
                a24.Text = s;
                textBox2.Select(textBox2.TextLength, 0);
            }
        }

        private void Latitude_MouseClick(object sender, MouseEventArgs e)
        {
            int i = this.a25.SelectionStart;
            string s = this.a25.Text;
            if (textBox2.SelectedText != "")
            {
                textBox2.Select();
                string ss = textBox2.SelectedText;
                s = s.Insert(i, ss);
                a25.Text = s;
                textBox2.Select(textBox2.TextLength, 0);
            }

        }

        private void Longitude_MouseClick(object sender, MouseEventArgs e)
        {
            int i = this.a26.SelectionStart;
            string s = this.a26.Text;
            if (textBox2.SelectedText != "")
            {
                textBox2.Select();
                string ss = textBox2.SelectedText;
                s = s.Insert(i, ss);
                a26.Text = s;
                textBox2.Select(textBox2.TextLength, 0);
            }

        }

        private void Altitude_MouseClick(object sender, MouseEventArgs e)
        {

            int i = this.a27.SelectionStart;
            string s = this.a27.Text;
            if (textBox2.SelectedText != "")
            {
                textBox2.Select();
                string ss = textBox2.SelectedText;
                s = s.Insert(i, ss);
                a27.Text = s;
                textBox2.Select(textBox2.TextLength, 0);
            }
        }
        
        public void Search(TextBox textBox1)
        {
            //string forcollector1 = @"((?=Dr).+(?<=z)|(?=H).{0,30}(?<=e|m|n)|(?=S).{0,30}(?<=n))";
            string input = textBox1.Text;
            noteinfo = "";
            string forbarcode = @"(([A-Z][ ]?)(\d{2}[ ]?\d{6,8}))";
            foreach (Match m in Regex.Matches(input, forbarcode))
            {
                a3.Text = m.Groups[1].Value;
                a3.BackColor = Color.White;
            }

            //string forcollector1 = @"((?=Dr).+(?<=z)|(?=H).{0,30}(?<=e|m|n)|(?=S).{0,30}(?<=n))";
            string forcollector = @"(?:leg. )(.{1,21})|(?:Coll.)(\D{1,18})|(?:Colector:)(.{1,30})";
            foreach (Match m in Regex.Matches(input, forcollector))
            {
                if (m.Groups[1].Value == null)
                {
                    if (m.Groups[2].Value == null)
                        a6.Text = m.Groups[3].Value;
                    else
                        a6.Text = m.Groups[2].Value;
                    a6.BackColor = Color.White;
                }
                else
                    a6.Text = m.Groups[1].Value;   
                    a6.BackColor = Color.White;
            }

            string forherbar = @"(?<=Herbarium[ ]?)\w{1,10}";    //(?:HOLOTYPE,)(.{0,4})   //|([Ex Herb].{1,10}  @"[Mus].{1,10}\w{1,10}"
            foreach (Match m in Regex.Matches(input, forherbar))
            {
                a8.Text = m.Value;
                a8.BackColor = Color.White;
            }

            string forfamily = @"(?:Flora ).{1,11}|(?:Bego).{1,8}";    //(?:HOLOTYPE,)(.{0,4})   //|([Ex Herb].{1,10}  @"[Mus].{1,10}\w{1,10}"
            foreach (Match m in Regex.Matches(input, forfamily))
            {
                a11.Text = m.Value;
                a11.BackColor = Color.White;
            }

            string fordate = @"[.]?\d{4}[.]?\s{1}";  //(?:[Die])[:]?[ ]?[\w]{15}
            foreach (Match m in Regex.Matches(input, fordate))
            {
                //if (m.Groups[1].Value==null)
                a17.Text = m.Value;
                //else
                //    a17.Text = m.Groups[1].Value;
                a17.BackColor = Color.White;
            }
            string fordet = @"(?:det).{1,20}";  //(?:[Die])[:]?[ ]?[\w]{15}
            foreach (Match m in Regex.Matches(input, fordet))
            {
                a16.Text = m.Value;                
                a16.BackColor = Color.White;
            }


            string forcountry = @"[(?<=P)][A-Z]{4,5}|[B]?[r]?[a-z]{6,9}";
            foreach (Match m in Regex.Matches(input, forcountry))
            {
                a18.Text = m.Value;
                a18.BackColor = Color.White;
            }
            string forstate = @"(?:Provincia:)(.{1,13})";
            foreach (Match m in Regex.Matches(input, forstate))
            {
                a19.Text = m.Groups[1].Value;
                a19.BackColor = Color.White;
            }
            string forHabitat = @"(?:Hab.).{1,50}(?:\n).{1,60}(?:\n).{1,60}(?:\n).{1,60}";
            foreach (Match m in Regex.Matches(input, forHabitat))
            {
                a20.Text = m.Value;
                a20.BackColor = Color.White;
            }



            string fornoteAccessit = @"[acc][.]?\w{2,3}[.]?\w{2,3}[.]?\d{4,5}";
            foreach (Match m in Regex.Matches(input, fornoteAccessit))
            {
                if (m.Value != null)
                    noteinfo = m.Value; ;
                a22.Text = noteinfo;
                a22.BackColor = Color.White;
            }
            string fornoteAcquiriet = @"[Acqu.]\d{4}[ ]?\w{3}";
            foreach (Match m in Regex.Matches(input, fornoteAcquiriet))
            {
                if (m.Value != null)
                    noteinfo = "\r\n" + m.Value; ;
                a22.Text = noteinfo;
                a22.BackColor = Color.White;
            }
            string fornoteAd = @"(?:z.Bsp.Ad)[ ]?\w{1,30}";
            foreach (Match m in Regex.Matches(input, fornoteAd))
            {
                if (m.Value != null)
                    noteinfo = "\r\n" + m.Value; ;
                a22.Text = noteinfo;
                a22.BackColor = Color.White;
            }
            string fornoteCommunicavit = @"(?:communic.).{1,20}";
            foreach (Match m in Regex.Matches(input, fornoteCommunicavit))
            {
                if (m.Value != null)
                    noteinfo = "\r\n" + m.Value; ;
                a22.Text = noteinfo;
                a22.BackColor = Color.White;
            }
            string fornoteConfirmavit = @"(?:det).{1,20}";
            foreach (Match m in Regex.Matches(input, fornoteConfirmavit))
            {
                if (m.Value != null)
                { noteinfo = "\r\n" + m.Value; ;}
                a22.Text = noteinfo;
                a22.BackColor = Color.White;
            }
            string fornoteCult = @"(?:Cult.in horto).{1,20}";
            foreach (Match m in Regex.Matches(input, fornoteCult))
            {
                if (m.Value != null)
                    noteinfo = "\r\n" + m.Value;
                a22.Text = noteinfo;
                a22.BackColor = Color.White;
            }
            string fornoteBotanical = @"(?:Museum botanicum).{1,14}";
            foreach (Match m in Regex.Matches(input, fornoteBotanical))
            {
                if (m.Value != null)
                { noteinfo = "\r\n" + m.Value; ;}
                a22.Text = noteinfo;
                a22.BackColor = Color.White;
            }
            //string fornoteDet = @"[(det.)|(Det.)|(determ.)|(Determinó)].{1,20}";
            //foreach (Match m in Regex.Matches(input, fornoteDet))
            //{
            //    noteinfo = "\r\n" + m.Value; ;
            //    a22.Text = noteinfo;
            //    a22.BackColor = Color.White;
            //} 

            string fornoteDupl = @"(?:Dupl).{1,25}";
            foreach (Match m in Regex.Matches(input, fornoteDupl))
            {
                if (m.Value != null)
                    noteinfo = "\r\n" + m.Value; ;
                a22.Text = noteinfo;
                a22.BackColor = Color.White;
            }
            string fornoteFide = @"(?:Fide).{1,40}";
            foreach (Match m in Regex.Matches(input, fornoteFide))
            {
                if (m.Value != null)
                    noteinfo = "\r\n" + m.Value; ;
                a22.Text = noteinfo;
                a22.BackColor = Color.White;
            }



            string forlatitude = @"\d{2}.{6,10}[S]";
            foreach (Match m in Regex.Matches(input, forlatitude))
            {
                a25.Text = m.Value;
                Console.WriteLine();
                a25.BackColor = Color.White;
            }
            string forlongitude = @"\d{2}.{6,13}[W|V]";
            foreach (Match m in Regex.Matches(input, forlongitude))
            {
                a26.Text = m.Value;
                a26.BackColor = Color.White;
            }
            string foraltitude = @"(\d{1,4}.?[m])|((?:Att.: )(\d{1,4}))|((\d{4})[ ]?[feet])";
            foreach (Match m in Regex.Matches(input, foraltitude))
            {
                a27.Text = m.Value;
                a27.BackColor = Color.White;
            }
            /* string fordate = @".{0,4}\d{1,2}.{0,5}\d{4}.{0,1}";
             foreach (Match m in Regex.Matches(input, fordate))
                 dateTimePicker1.Text = m.Value;
            */
            String strEingabe;
            strEingabe = a7.Text;
            string str = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            string[] meineArray = System.IO.File.ReadAllLines(str + "collector_sortiert1.txt");
            int[] meineArray2;
            meineArray2 = new int[meineArray.Length];
            myLevenshteinDistance = new LevenshteinDistance();

            for (int a = 0; a < meineArray.Length; a++)
            {
                //Console.WriteLine("LevenshteinDistance ist:{0}", LevenshteinDistance.Compute(strEingabe, meineArray[a]));
                meineArray2[a] = LevenshteinDistance.Compute(strEingabe, meineArray[a]);
                //Console.ReadLine();
            }
            int min = meineArray2[0], keep = 0;
            for (int a = 0; a < meineArray.Length; a++)
            {
                if (min >= meineArray2[a])
                {
                    min = meineArray2[a];
                    keep = a;
                }
            }
            a7.Text = meineArray[keep];
        }
        private void imageToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
                {
                    myVerarbeitungen = new Verarbeitungen();
                    pictureBox1.Image = myVerarbeitungen.LoadImage(openFileDialog1.FileName);
                    form2.pictureBox1.Image = pictureBox1.Image;
                    loadiamgepath = openFileDialog1.FileName;
                    string directoryName = Path.GetDirectoryName(openFileDialog1.FileName);
                    ImagefilePath = directoryName + @"\";
                    //textBox2.Text = ImagefilePath;
                    fileEntries = Directory.GetFiles(ImagefilePath, "*.bmp");
                    
                }
                openFileDialog1.Dispose();
                Switch = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //OpenFileDialog fileDialog = new OpenFileDialog();
            //fileDialog.Multiselect = false;
            //if (fileDialog.ShowDialog() == DialogResult.OK)
            //{

            //    FileStream pFileStream = new FileStream(fileDialog.FileName, FileMode.Open, FileAccess.Read);
            //    Image myimage = Image.FromStream(pFileStream);
            //    pFileStream.Close();
            //    pFileStream.Dispose();
            //    pictureBox1.Image = myimage;
            //    loadiamgepath = fileDialog.FileName;
            //}
            
        
        }
        //private void txtToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    myVerarbeitungen = new Verarbeitungen();
        //    textBox2.Text = myVerarbeitungen.Loadtxt(); 
        //}
        private void xmlToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                myVerarbeitungen = new Verarbeitungen();
                string xmlpath = myVerarbeitungen.Loadxml();
                myVerarbeitung = new Verarbeitung1();
                myVerarbeitung.xmleinlesen(xmlpath);
                string directoryName = Path.GetDirectoryName(xmlpath);
                XMLfilePath = directoryName + @"\";
                fileEntries2 = Directory.GetFiles(XMLfilePath, "*.xml");
                textBox2.Text = null;
                foreach (string element in myVerarbeitung.llist)
                {
                    textBox2.Text += element + "\r\n";
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                Search(textBox2);
            }
            catch (Exception)
            { }
        }

        //public DashStyle Solid { get; set; }
        private void numericUpDown1_ValueChanged_1(object sender, EventArgs e)
        {
            foreach (Control ctrl in this.Controls)//或为groupBox1.Controls/panel1.Controls
            {
                ctrl.Font = new Font(this.textBox2.Font.FontFamily, (float)this.a28.Value);
            }
        }
        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (a29.Checked == true)
            {

                foreach (Control ctrl in this.Controls)//或为groupBox1.Controls/panel1.Controls
                {
                    ctrl.Font = new Font(ctrl.Font, FontStyle.Bold);
                }
            }
            else
            {
                foreach (Control ctrl in this.Controls)
                    ctrl.Font = new Font(ctrl.Font, FontStyle.Regular);
            }
        }
        private void xmlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pCurrentwin = this;
            myVerarbeitungen = new Verarbeitungen();
            XmlDocument doc = myVerarbeitungen.xml();
           
        }
        private void jsonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pCurrentwin = this;
            myVerarbeitungen = new Verarbeitungen();
            myVerarbeitungen.json();
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in panel1.Controls)
            {
                if (ctrl is TextBox || ctrl is ComboBox)
                {
                    ctrl.Text = "";
                    ctrl.BackColor = Color.LightYellow;
                }
            }
        }

        //private static void ShowHerbariumSheetCreationDialog()
        //{
        //    Console.WriteLine("Name of herbarium sheet: ");
        //    string name = Console.ReadLine().Trim();

        //    if (String.IsNullOrEmpty(name))
        //    {
        //        Console.WriteLine("Name is empty. Operation cancelled.");
        //        return;
        //    }

        //    Authenticate();

        //    int id = service.CreateHerbariumSheet(name);

        //    Console.WriteLine(String.Format("An herbarium sheet with ID:{0} was successfully created.", id));
        //}




        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            try
            {
                j++;
                bool IfTimesEnd = false;
                if (j == 2)
                {
                    t.Start();// thread begin       
                    IfTimesEnd = t.IsAlive; // know if the Thread still is running!     
                    if (!IfTimesEnd)
                    {
                        //t.Abort();
                        j--;

                    }
                }
                else
                {
                    if ((j % 2) == 1)
                        t.Suspend();// thread to wait
                    else
                        t.Resume();// go on
                }
                Switch = false;
            }
            catch (Exception)
            {
                controlnumber = 0;
                j = 1;
            }
        }
        private void Form1_Close(object sender, EventArgs e)
        {
                  t.Abort();
 
        }
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            try
            {
                controlnumber = controlnumber - 1;
                if (controlnumber < 0)
                {
                    controlnumber = 0;
                    MessageBox.Show("Attention: No more Images! Don't press the button << !");
                }
                a5.Text = Path.GetFileName(fileEntries[controlnumber]);
                FileStream pFileStream = new FileStream(fileEntries[controlnumber], FileMode.Open, FileAccess.Read);
                pictureBox1.Image = Image.FromStream(pFileStream);
                form2.pictureBox1.Image = pictureBox1.Image;
                pFileStream.Close();
                pFileStream.Dispose();
                myVerarbeitung = new Verarbeitung1();
                String xmlfilename = fileEntries2[controlnumber];
                myVerarbeitung.xmleinlesen(xmlfilename);
                textBox2.Text = null;
                foreach (string element in myVerarbeitung.llist)
                {
                    textBox2.Text += element + "\r\n";
                }
                //Search(textBox2);
                Switch = false;
            }
            catch (Exception)
            {
                
                MessageBox.Show("there is no document");
            }
            try
            {
                Search(textBox2);
            }
            catch (Exception)
            { return; }
        }
        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            try
            {
                controlnumber = controlnumber + 1;
                if (controlnumber > fileEntries.Length - 1)
                {
                    controlnumber = fileEntries.Length - 1;
                    MessageBox.Show("It's the last Image!");
                }
                a5.Text = Path.GetFileName(fileEntries[controlnumber]);
                FileStream pFileStream = new FileStream(fileEntries[controlnumber], FileMode.Open, FileAccess.Read);
                pictureBox1.Image = Image.FromStream(pFileStream);
                form2.pictureBox1.Image = pictureBox1.Image;
                pFileStream.Close();
                pFileStream.Dispose();
                //String sr = @fileEntries1[controlnumber];
                //StreamReader str = new StreamReader(sr, Encoding.GetEncoding("gb2312"));
                myVerarbeitung = new Verarbeitung1();
                String xmlfilename = fileEntries2[controlnumber];
                myVerarbeitung.xmleinlesen(xmlfilename);
                //xml.Text = null;
                //foreach (string element in myVerarbeitung.mlist)
                //{
                //    xml.Text += element + "\r\n";
                //}
                textBox2.Text = null;
                foreach (string element in myVerarbeitung.llist)
                {
                    textBox2.Text += element + "\r\n";
                }
                
                Switch = false;
            }
            
            catch (Exception)
            {

                MessageBox.Show("there is no document");
            }
            try
            {
                Search(textBox2);
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void family_KeyUp(object sender, KeyEventArgs e)
        {
           
            //if (e.KeyCode == Keys.Enter)
            //{
            //    myVerarbeitungen = new Verarbeitungen();
            //    myVerarbeitungen.FuzzySearchNames();
       
            //        //Lenvenstein(); 
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {  
            myVerarbeitungen = new Verarbeitungen();
            myVerarbeitungen.Lenvenstein();
        }
        private void downloadHerbariumSheetFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                textBox2.Text = null;
                Verarbeitungen myVerarbeitungen = new Verarbeitungen();
                string path = myVerarbeitungen.ShowHerbariumSheetDownloadDialog();
                myVerarbeitung = new Verarbeitung1();
                //string[] xmlpath = Directory.GetFiles(XMLfilePath, "*.xml");
                //string[] imagepath = Directory.GetFiles(XMLfilePath, "*.jpg");
                myVerarbeitung.xmleinlesen(path);
                foreach (string element in myVerarbeitung.llist)
                {
                    textBox2.Text += element + "\r\n";
                }
            }
            catch (Exception)
            {
                return;
            }
        }   

        private void textBox2_DoubleClick(object sender, EventArgs e)
        {


            Point p0 = new Point { X = 0, Y = 0 };
            Point p1 = new Point { X = 0, Y = 0 };
            foreach (OcrWord element in myVerarbeitung.ocrList)
            {
                if (textBox2.SelectedText == element.text || textBox2.SelectedText == element.text + " " || textBox2.SelectedText == element.text + ".")
                {
                    p0 = new Point { X = element.position.X, Y = element.position.Y };
                    p1 = new Point { X = element.position.X + element.position.Width, Y = element.position.Y + element.position.Height };
                }
            }
            drawingrectangular = new image_rectangule_drawing();
            if (checkBox2.Checked == true)
            {
                pictureBox1.Image = drawingrectangular.DrawRectangleInPicture(pictureBox1.Image, p0, p1, Color.Red, 6);
                form2.pictureBox1.Image = pictureBox1.Image;
            }
            else
            {
                if (Switch == false)
                { 
                    FileStream pFileStream = new FileStream(fileEntries[controlnumber], FileMode.Open, FileAccess.Read);
                    Image image = Image.FromStream(pFileStream);
                    pFileStream.Close();
                    pFileStream.Dispose();
                    pictureBox1.Image = drawingrectangular.DrawRectangleInPicture(image, p0, p1, Color.Red, 6);
                    form2.pictureBox1.Image = pictureBox1.Image;
                }
                if (Switch == true)
                {
                    FileStream pFileStream = new FileStream(loadiamgepath, FileMode.Open, FileAccess.Read);
                    Image image = Image.FromStream(pFileStream);
                    pFileStream.Close();
                    pFileStream.Dispose();
                    pictureBox1.Image = drawingrectangular.DrawRectangleInPicture(image, p0, p1, Color.Red, 6);
                    form2.pictureBox1.Image = pictureBox1.Image;
                }
                
            }
        }
    

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
           login = new Login();
            if (!n)
            {
                login.Show();

            }
            else
            {
                Verarbeitungen myVerarbeitungen = new Verarbeitungen();
                WebGenesis.Text = "login";
                n = false;
                myVerarbeitungen.CloseSession();

            } 
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            form2 = new image();
            form2.pictureBox1.Image = pictureBox1.Image;
            form2.Show();
        }

        private void uploadFileToExistingHerbariumSheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Verarbeitungen myVerarbeitungen = new Verarbeitungen();
            myVerarbeitungen.ShowHerbariumSheetUploadDialog();
        }

        private void onLocalPathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog FilDialog = new SaveFileDialog();
            FilDialog.Dispose();
            //build ein drectory to save.
        }


        private void templateMachtingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
                {
                    myVerarbeitungen = new Verarbeitungen();
                    Bitmap mybitmap = myVerarbeitungen.TemplateMaching(loadiamgepath, openFileDialog1.FileName);
                    pictureBox1.Image = mybitmap;
                    form2.pictureBox1.Image = pictureBox1.Image;
                   
                }
                openFileDialog1.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void inverterToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                myVerarbeitungen = new Verarbeitungen();
                pictureBox1.Image = myVerarbeitungen.invert(loadiamgepath);                               // Weise picturebox1 das invertiterte Bild zu
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void jsonsaving_Click(object sender, EventArgs e)
        {
            myVerarbeitungen = new Verarbeitungen();
            myVerarbeitungen.json();
        }

        private void a15_TextChanged(object sender, EventArgs e)
        {
            myVerarbeitungen = new Verarbeitungen();
            myVerarbeitungen.FuzzySearchNames();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Search(textBox2);
        }

 
    }
}
