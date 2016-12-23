using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using OpenCvSharp;
using System.IO;
using System.Xml;
using System.Reflection;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using StandAPHerbWebGenesisServices;

//using System.Web.Script.Serialization;


namespace WindowsFormsApplication1
{
    class Verarbeitungen
    {
        private static StandAPHerbService service = new StandAPHerbService();
        public IplImage myImage;
        public IplImage myTemplateimage;
        public IplImage dst;
        public List<string> possiblenames = new List<string>();
        image form2=new image();
        public Bitmap bitmap
        {
            get { return myImage.ToBitmap(); }
        }
        public Image LoadImage(String imagePath)
        {
                
                FileStream pFileStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read);
                Image myimage = Image.FromStream(pFileStream);
                pFileStream.Close();
                pFileStream.Dispose();
                return myimage;
                
        }
        //public string Loadtxt()
        //{
        //    OpenFileDialog fileDialog = new OpenFileDialog();
        //    fileDialog.Multiselect = true;
        //    if (fileDialog.ShowDialog() == DialogResult.OK)
        //    {

        //        string file = fileDialog.FileName;
        //        StreamReader sr = new StreamReader(file, Encoding.GetEncoding("gb2312"));
        //        string content = sr.ReadToEnd();
        //        string filename = System.IO.Path.GetDirectoryName(file);
        //        string path = file.Substring(file.LastIndexOf('\\') + 1, file.LastIndexOf('.') - file.LastIndexOf('\\') - 1);
        //        string filePath = Path.Combine(filename, path + ".xml");
        //        Verarbeitung1 myVerarbeitung = new Verarbeitung1();
        //        myVerarbeitung.xmleinlesen(filePath);
        //        content = null;
        //        foreach (string element in myVerarbeitung.llist)
        //        {

        //            content += element + "\r\n";
        //        }
        //        return content;
        //    }
        //    return null;
        //}
        public string Loadxml()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string file = fileDialog.FileName;
                return file;
            }
            return null;
        }
        public XmlDocument xml()
        {
            XmlDocument doc = new XmlDocument();
            XmlElement root = doc.CreateElement("Project"); // 创建根节点album
            root.SetAttribute("Name", "HerbSAP-Herb"); // 设置属性 
            XmlElement preview = doc.CreateElement("Preview");  // 创建preview元素
            //List<Control> buttonList = new List<Control>();
            //List<Control> contentList = new List<Control>();

            //foreach (Control c in PLIES.pCurrentwin.Controls)
            //{
            //    if (c is Button)
            //    {
            //        buttonList.Add(c);
            //    }
            //    if (c is TextBox ||c is ComboBox)
            //   {             
            //        contentList.Add(c);
            //   }
            //}

            //for (int i = 0; i < buttonList.Count; i++)
            //{
            //    //PLIES.pCurrentwin.textBox2.Text = buttonList[i].ToString();
            //    string text = buttonList[i].Text;
            //    string content = contentList[i].Text;
            //    preview.SetAttribute(text, content);
            //}


            preview.SetAttribute(PLIES.pCurrentwin.button3.Text, PLIES.pCurrentwin.a3.Text);  // put information into preview [like colletor Steffen]
            preview.SetAttribute(PLIES.pCurrentwin.button4.Text, PLIES.pCurrentwin.a4.Text);
            preview.SetAttribute(PLIES.pCurrentwin.button5.Text, PLIES.pCurrentwin.a5.Text);
            preview.SetAttribute(PLIES.pCurrentwin.button6.Text, PLIES.pCurrentwin.a6.Text);
            preview.SetAttribute(PLIES.pCurrentwin.button7.Text, PLIES.pCurrentwin.a7.Text);
            preview.SetAttribute(PLIES.pCurrentwin.button8.Text, PLIES.pCurrentwin.a8.Text);
            preview.SetAttribute(PLIES.pCurrentwin.button9.Text, PLIES.pCurrentwin.a9.Text);
            preview.SetAttribute(PLIES.pCurrentwin.button10.Text, PLIES.pCurrentwin.a10.Text);
            preview.SetAttribute(PLIES.pCurrentwin.button11.Text, PLIES.pCurrentwin.a11.Text);
            preview.SetAttribute(PLIES.pCurrentwin.button12.Text, PLIES.pCurrentwin.a12.Text);
            preview.SetAttribute(PLIES.pCurrentwin.button13.Text, PLIES.pCurrentwin.a13.Text);
            preview.SetAttribute(PLIES.pCurrentwin.button13.Text, PLIES.pCurrentwin.a14.Text);
            preview.SetAttribute(PLIES.pCurrentwin.button14.Text, PLIES.pCurrentwin.a15.Text);
            preview.SetAttribute(PLIES.pCurrentwin.button15.Text, PLIES.pCurrentwin.a16.Text);
            preview.SetAttribute(PLIES.pCurrentwin.button16.Text, PLIES.pCurrentwin.a17.Text);
            preview.SetAttribute(PLIES.pCurrentwin.button17.Text, PLIES.pCurrentwin.a18.Text);
            preview.SetAttribute(PLIES.pCurrentwin.button18.Text, PLIES.pCurrentwin.a19.Text);
            preview.SetAttribute(PLIES.pCurrentwin.button19.Text, PLIES.pCurrentwin.a20.Text);
            preview.SetAttribute(PLIES.pCurrentwin.button20.Text, PLIES.pCurrentwin.a20.Text);
            preview.SetAttribute(PLIES.pCurrentwin.button21.Text, PLIES.pCurrentwin.a21.Text);
            preview.SetAttribute(PLIES.pCurrentwin.button22.Text, PLIES.pCurrentwin.a22.Text);
            preview.SetAttribute(PLIES.pCurrentwin.button23.Text, PLIES.pCurrentwin.a23.Text);
            preview.SetAttribute(PLIES.pCurrentwin.button24.Text, PLIES.pCurrentwin.a24.Text);
            preview.SetAttribute(PLIES.pCurrentwin.button25.Text, PLIES.pCurrentwin.a25.Text);
            preview.SetAttribute(PLIES.pCurrentwin.button26.Text, PLIES.pCurrentwin.a26.Text);
            preview.SetAttribute(PLIES.pCurrentwin.button27.Text, PLIES.pCurrentwin.a27.Text);
            root.AppendChild(preview);
            doc.AppendChild(root);
            try
            {
                Stream myStream;
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if ((myStream = saveFileDialog1.OpenFile()) != null)
                    {
                        // Code to write the stream goes here.
                        myStream.Close();
                    }
                }
                //path = "C:\\Users\\zhengh\\Desktop\\Project  Update\\" + PLIES.pCurrentwin.a5.Text + ".xml";
                doc.Save(saveFileDialog1.FileName);
                MessageBox.Show("The xml datas have been saved!");
            }
            catch (Exception)
            { MessageBox.Show("please give the right path"); }
            return doc;
        }
        public static string GetAssemblyPath()
        {
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);

            return Path.GetDirectoryName(path);
        }

        public static void WriteToFile(string path, byte[] content)
        {
            using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                fs.Write(content, 0, content.Length);
            }
        }


        public void Lenvenstein()
        {
            int anfang, ende, mitte, Suchschritt;
            int[] meineArray2;
            string x;
            x = PLIES.pCurrentwin.a15.Text.ToUpper();
            PLIES.pCurrentwin.a15.Modified = true;
            PLIES.pCurrentwin.a15.Text = x;    //name.Refresh(x);
            string str = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            string[] meineArray = System.IO.File.ReadAllLines(str + "pflanzen_neu_sortiert2.txt");

            anfang = 0;
            ende = meineArray.Length - 1;
            Suchschritt = 0;
            do
            {
                Suchschritt++;
                mitte = (anfang + ende) / 2;

                if (x.CompareTo(meineArray[mitte]) > 0)
                {
                    anfang = mitte + 1;
                }
                else
                {
                    ende = mitte - 1;
                }
            } while ((x.CompareTo(meineArray[mitte]) != 0) && (anfang <= ende));

            if (x.CompareTo(meineArray[mitte]) == 0)
            {
                PLIES.pCurrentwin.a15.Text = meineArray[mitte];
            }
            else
            {
                meineArray2 = new int[meineArray.Length];
                LevenshteinDistance myLevenshteinDistance = new LevenshteinDistance();

                for (int i = 0; i < meineArray.Length; i++)
                {
                    meineArray2[i] = LevenshteinDistance.Compute(x, meineArray[i]);
                }
                int min = meineArray2[0], keep = 0;
                for (int i = 0; i < meineArray.Length; i++)
                {
                    if (min >= meineArray2[i])
                    {
                        min = meineArray2[i];
                        keep = i;
                    }
                }
                PLIES.pCurrentwin.a15.Text = meineArray[keep];
            }
        }
        public void FuzzySearchNames()
        {
            try
            {
                WebClient client = new WebClient();
                string InputName = PLIES.pCurrentwin.a15.Text;
                if (string.IsNullOrEmpty(InputName))
                {
                    return;
                }
                string URL1 = "api.cybertaxonomy.org:80/col/doc/../name_catalogue/fuzzy.json?query=";
                string URL2 = "&accuracy=0.6&hits=10&type=name";
                Uri URL = new Uri("http://" + URL1 + InputName + URL2);
                Stream stream = client.OpenRead(URL);
                StreamReader reader = new StreamReader(stream);
                string jsonstr = reader.ReadToEnd();

                if (string.IsNullOrEmpty(jsonstr) | jsonstr.Contains("errorMessage"))
                {
                    return;// MessageBox.Show("Name is Not Found. Operation cancelled.");
                }
 
                JArray jArray = JArray.Parse(jsonstr);
                dynamic x;
           
            
                var message = jArray[0]["response"].ToString();   //when the Json is not match, it will report a mistake(no instance of the object)
                JArray Jar = JArray.Parse(message);
                x = Newtonsoft.Json.JsonConvert.DeserializeObject(Jar.ToString());
                foreach (var listname in x)
                {
                    string Name1 = listname.name;
                    possiblenames.Add(Name1);
                }
                AutoCompleteStringCollection myCutomSource = new AutoCompleteStringCollection();
                System.String[] textboxnames = possiblenames.ToArray();
                myCutomSource.AddRange(textboxnames);
                PLIES.pCurrentwin.a15.AutoCompleteCustomSource = myCutomSource;
                stream.Close();
            }
            catch (Exception)
            {
                return; //MessageBox.Show("Name is Not Found. Operation cancelled");
            }

            //stream.Close();
        }
        public void json()
        {   //準備資料 
            string apiVersion = "0.1";
            string searchedTerm = PLIES.pCurrentwin.a15.Text;
            int numMatches = 1;
            string barcode = PLIES.pCurrentwin.a3.Text;
            string accession = PLIES.pCurrentwin.a4.Text;
            string imagenumber = PLIES.pCurrentwin.a5.Text;
            string collector = PLIES.pCurrentwin.a6.Text;
            string collectornumber = PLIES.pCurrentwin.a7.Text;
            string locality = PLIES.pCurrentwin.a8.Text;
            string othercollector = PLIES.pCurrentwin.a9.Text;
            string date = PLIES.pCurrentwin.a10.Text;
            string family = PLIES.pCurrentwin.a11.Text;
            string genus = PLIES.pCurrentwin.a12.Text;
            string specise = PLIES.pCurrentwin.a13.Text;
            string subspecise = PLIES.pCurrentwin.a14.Text;
            string sceintificname = PLIES.pCurrentwin.a15.Text;
            string determiner = PLIES.pCurrentwin.a16.Text;
            string determinerdate = PLIES.pCurrentwin.a17.Text;
            string country = PLIES.pCurrentwin.a18.Text;
            string StateorProvice = PLIES.pCurrentwin.a19.Text;
            string hebitat = PLIES.pCurrentwin.a20.Text;
            string scripts = PLIES.pCurrentwin.a21.Text;
            string notes = PLIES.pCurrentwin.a22.Text;
            string unioit = PLIES.pCurrentwin.a23.Text;
            string TopKD = PLIES.pCurrentwin.a24.Text;
            string latitude = PLIES.pCurrentwin.a25.Text;
            string longitude = PLIES.pCurrentwin.a26.Text;
            string altitude = PLIES.pCurrentwin.a27.Text;
            string fortsize = PLIES.pCurrentwin.a28.Value.ToString();
            bool bold = PLIES.pCurrentwin.a29.Checked;

            //建立物件，塞資料 
            Fort forts = new Fort();
            forts.fortsize = fortsize;
            forts.fortbold = bold;
            Match matches = new Match();
            matches.barcode = barcode;  // { get; set; }
            matches.accession = accession;  // { get; set; }
            matches.imagenumber = imagenumber;  // { get; set; }
            matches.collector = collector;  // { get; set; }
            matches.colletornumber = collectornumber;  // { get; set; }
            matches.locality = locality;  // { get; set; }
            matches.othercollector = othercollector;  // { get; set; }
            matches.date = date;  // { get; set; }
            matches.family = family;  // { get; set; }
            matches.genus = genus;  // { get; set; }
            matches.specise = specise;  // { get; set; }
            matches.subspecise = subspecise;  // { get; set; }
            matches.sceintificname = sceintificname;  // { get; set; }
            matches.determiner = determiner;  // { get; set; }
            matches.determinerdate = determinerdate;  // { get; set; }
            matches.coutry = country;  // { get; set; }
            matches.state = StateorProvice;  // { get; set; }
            matches.hebitat = hebitat;  // { get; set; }
            matches.scripts = scripts;  // { get; set; }
            matches.notes = notes;  // { get; set; }
            matches.unioit = unioit;  // { get; set; }
            matches.topkd = TopKD;  // { get; set; }
            matches.latitude = latitude;  // { get; set; }
            matches.longitude = longitude;  // { get; set; }
            matches.altitude = altitude;  // 
            matches.fort.Add(forts);
            Result results = new Result();
            results.searchedTerm = searchedTerm;
            results.numMatches += numMatches;
            results.matches.Add(matches);
            RootObject root = new RootObject();
            root.apiVersion = apiVersion;
            root.results.Add(results);

            //物件序列化 
            string strJson = JsonConvert.SerializeObject(root);

            //輸出結果  
            //Console.WriteLine(strJson);
           try
            {
                Stream myStream;
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if ((myStream = saveFileDialog1.OpenFile()) != null)
                    {
                        // Code to write the stream goes here.
                        myStream.Close();
                    }
                }
                StreamWriter sw = new StreamWriter(saveFileDialog1.FileName, false, System.Text.Encoding.UTF8);
                sw.Write(strJson);
                sw.Close();
                sw.Dispose();
                MessageBox.Show("The json datas have been saved!");
                //path = "C:\\Users\\zhengh\\Desktop\\Project  Update\\" + PLIES.pCurrentwin.a5.Text + ".xml"
            }
            catch (Exception )
            { MessageBox.Show("please give the right path"); }
           
            //strJson.(path);

        }

        public class Fort
        {
            public string fortsize;  //{ get; set; }
            public bool fortbold;   // { get; set; }
        }
        public class Match
        {
            public string barcode;  // { get; set; }
            public string accession;  // { get; set; }
            public string imagenumber;  // { get; set; }
            public string collector;  // { get; set; }
            public string colletornumber;  // { get; set; }
            public string locality;  // { get; set; }
            public string othercollector;  // { get; set; }
            public string date;  // { get; set; }
            public string family;  // { get; set; }
            public string genus;  // { get; set; }
            public string specise;  // { get; set; }
            public string subspecise;  // { get; set; }
            public string sceintificname;  // { get; set; }
            public string determiner;  // { get; set; }
            public string determinerdate;  // { get; set; }
            public string coutry;  // { get; set; }
            public string state;  // { get; set; }
            public string hebitat;  // { get; set; }
            public string scripts;  // { get; set; }
            public string notes;  // { get; set; }
            public string unioit;  // { get; set; }
            public string topkd;  // { get; set; }
            public string latitude;  // { get; set; }
            public string longitude;  // { get; set; }
            public string altitude;  // { get; set; }
            public List<Fort> fort = new List<Fort>();  // { get; set; }
        }
        public class Result
        {
            public string searchedTerm;  // { get; set; }
            public int numMatches;  // { get; set; }
            public List<Match> matches = new List<Match>();  // { get; set; }
        }
        public class RootObject
        {
            public string apiVersion;  // { get; set; }
            public List<Result> results = new List<Result>();  // { get; set; }
        }
       
        public void ShowHerbariumSheetsSinceTimeDialog()
        {

            //string datetime = Form1.pCurrentWin.Timesince.Text;
            string datetime = "2014-01-01T12:00:00.00";//Console.WriteLine("Show herbarium sheets modified since datetime (format: yyyy-MM-ddTHH:mm:ss.SS):");
            if (String.IsNullOrEmpty(datetime))
            {
                MessageBox.Show("No datetime provided. Operation cancelled.");
                return;
            }
            Authenticate();

            int[] ids = service.GetModifiedHerbariumSheetIDsSince(datetime);

            for (int d = 0; d < ids.Length; d++)
                PLIES.pCurrentwin.HerbariumID.Items.Add(ids[d]);
        }
        public void Authenticate()
        {

            if (!service.LoggedIn)
            {
                try
                {
                    Login.pCurrentwin.Show();
                    string username = Login.pCurrentwin.username.Text;
                    string password = Login.pCurrentwin.password.Text;
                    service.Login(username, password);
                    PLIES.pCurrentwin.n = true;
                    Login.pCurrentwin.Close();
                    PLIES.pCurrentwin.WebGenesis.Text = "logout";
                    //PLIES.pCurrentwin.Show();
                    MessageBox.Show("connected with WebGeneses!");
                }
                catch (WebGenesisServiceException)
                {
                    Login.pCurrentwin.username.Text = null;
                    Login.pCurrentwin.password.Text = null;
                    MessageBox.Show(" Username or Password ist wrong! Please LOGIN IN again ");
                    return;

                }
            }
        }
        public void CloseSession()
        {
            if (service.LoggedIn)
            {
                try
                {
                    service.Dispose();
                }
                catch (WebGenesisServiceException)
                {
                    MessageBox.Show("Logout failed.");
                }

                MessageBox.Show("Logged out.");
            }
        }
        public string ShowHerbariumSheetDownloadDialog()
        {
            string herbariumIdInput = PLIES.pCurrentwin.HerbariumID.Text.Trim(); //Console.ReadLine().Trim();
            if (String.IsNullOrEmpty(herbariumIdInput))
            {
                MessageBox.Show("Invalid ID. Operation cancelled.");
                return null;
            }
            int herbariumId;
            try
            {
                herbariumId = Convert.ToInt32(herbariumIdInput);
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid ID. Operation cancelled.");
                return null;
            }
            string defaultDir = GetAssemblyPath();
            string dir = null;    
            if (String.IsNullOrEmpty(dir) || !File.Exists(dir))
            {
                dir = defaultDir;
            }
            try { Authenticate();}
            catch (Exception) { 
                MessageBox.Show("You must Login to WebGenesis");
                Login login = new Login();
                login.Show();
                return null ;
            }
            string filePath = Path.Combine(dir, herbariumId + ".zip");
            string unZipDir = Path.Combine(dir, "unZipDir");
            try
            {
                Byte[] content = service.DownloadZipped(herbariumId);
                WriteToFile(filePath, content);
            }
            catch (Exception)
            {
                return null;
            }

            //clear the unzip directory before downloading
            DirectoryInfo di = new DirectoryInfo(unZipDir);
            try
            {
                di.Delete(true);
            }
            catch (System.IO.IOException e)
            {
                MessageBox.Show(e.Message);
            }
            MessageBox.Show("downloading........");
            Directory.CreateDirectory(unZipDir);
            UnZip(filePath, unZipDir);

            if (Directory.GetFiles(unZipDir).Length == 0)
            {
                MessageBox.Show("no file found");
            }
            else
            {
                string[] extention = { "*.jpg", "*.bmp", "*.tif", "*.TIf" };
                int picturejudge = 0;
                for (int k = 0; k < 4; k++)
                {
                    string[] Dir = Directory.GetFiles(unZipDir, extention[k]);
                    if (Dir.Length >= 1)
                    {   // OpenCVException a new Form;}      //two images
                        picturejudge++;
                        FileStream pFileStream = new FileStream(Dir[0], FileMode.Open, FileAccess.Read);
                        Image image = Image.FromStream(pFileStream);
                        pFileStream.Close();
                        pFileStream.Dispose();
                        PLIES.pCurrentwin.pictureBox1.Image = image;
                        form2.pictureBox1.Image = image;
                        //picture2 = new picture2();
                        //FileStream pFileStream1 = new FileStream(Dir[1], FileMode.Open, FileAccess.Read);
                        //Image image1 = Image.FromStream(pFileStream1);
                        //pFileStream1.Close();
                        //pFileStream1.Dispose();
                        //picture2.pictureBox1.Image = image1;
                        //picture2.Show();
                    }
                }
                Verarbeitung1 myVerarbeitung = new Verarbeitung1();
                try
                {
                    String[] xmlfilename = Directory.GetFiles(unZipDir, "*.xml");// fileEntries2[controlnumber];
                    string loadxmlpath = xmlfilename[0];
                    return loadxmlpath;
                }
                catch (Exception)
                {
                    MessageBox.Show("there is no \".xml\" files in the directory!");
                    return null; 
                }

                //PLIES.pCurrentwin.textBox2.Text = null;
                //foreach (OcrWord element in myVerarbeitung.combinedTextList)
                //{
                //    PLIES.pCurrentwin.textBox2.Text += element.text + "\r\n";
                //}
                //PLIES.pCurrentwin.Search(PLIES.pCurrentwin.textBox2);
            }
            //return unZipDir;
            return null;
        }
        

        public static void UnZip(string zipFile, string folderPath)
        {
            if (!File.Exists(zipFile))
                throw new FileNotFoundException();

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            Shell32.Shell objShell = new Shell32.Shell();
            Shell32.Folder destinationFolder = objShell.NameSpace(folderPath);
            Shell32.Folder sourceFile = objShell.NameSpace(zipFile);
            Shell32.FolderItems items = sourceFile.Items();
            foreach (var file in items)
            {
                destinationFolder.CopyHere(file, 4 | 16);
            }

            if (File.Exists(zipFile))
                File.Delete(zipFile);

        }
        public void ShowHerbariumSheetUploadDialog()
        {
            string herbariumIdInput = PLIES.pCurrentwin.HerbariumID.Text;

            if (String.IsNullOrEmpty(herbariumIdInput))
            {
                MessageBox.Show("Invalid ID. Operation cancelled.");
                return;
            }

            int herbariumId;

            try
            {
                herbariumId = Convert.ToInt32(herbariumIdInput);
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid ID. Operation cancelled.");
                return;
            }
            OpenFileDialog fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() != DialogResult.OK) return;
            //string Path = @"C:\Users\Cailin\Desktop\Project\WindowsFormsApplication1___NEU\WindowsFormsApplication1\bin\Debug\unZipDir\testjpg.jpg";
            if (!File.Exists(fileDialog.FileName))
            {
                MessageBox.Show("File does not exist. Operation cancelled.");
                return;
            }

            try { Authenticate(); }
            catch (Exception)
            {
                MessageBox.Show("You must Login to WebGenesis");
                Login login = new Login();
                login.Show();
                return;
            }
                
            MessageBox.Show("Uploading...");

            service.UploadFile(herbariumId, fileDialog.FileName);

            MessageBox.Show("Upload finished.");
        }
        public Bitmap TemplateMaching(String imagePath, String templateimagePath)
        {
            CvPoint min_loc = new CvPoint(0, 0);
            CvPoint max_loc = new CvPoint(0, 0);
            double min_val = 0;
            double max_val = 0;
            myImage = new IplImage(imagePath, LoadMode.GrayScale);
            myTemplateimage = new IplImage(templateimagePath, LoadMode.GrayScale);
            dst = new IplImage(new CvSize(myImage.Width - myTemplateimage.Width + 1, myImage.Height - myTemplateimage.Height + 1), BitDepth.F32, 1);
            myImage.MatchTemplate(myTemplateimage, dst, MatchTemplateMethod.CCoeffNormed);
            dst.MinMaxLoc(out min_val, out max_val, out min_loc, out max_loc);
            myImage.Rectangle(new CvRect(max_loc.X, max_loc.Y, myTemplateimage.Width+160, myTemplateimage.Height), CvColor.Red,5);
            return myImage.ToBitmap();
        }

        public Bitmap invert(string imagePath)
        {
            myImage = new IplImage(imagePath, LoadMode.GrayScale);
            if (myImage == null)                                                         // prüfen ob ein Bild geladen, 
                throw new Exception("Kein Bild geladen.");                               // wenn nicht dann Exception

            for (int y = 0; y < myImage.Height; y++)                                     // Durchlaufe alle Zeilen
            {
                for (int x = 0; x < myImage.Width; x++)                                  // Durchlaufe alle Spalten
                {
                    double grauPixel = 255 - myImage.Get2D(y, x);//[0];                     // Pixelwert lesen und invertieren
                    myImage.Set2D(y, x, grauPixel);                                      // Pixelwert setzten        
                }
            }
            return myImage.ToBitmap();
        }
   }
}
