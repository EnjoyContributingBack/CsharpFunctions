namespace CopyFiles
{
    public partial class frmCopyFile : Form
    {
        public frmCopyFile()
        {
            InitializeComponent();
        }

        private void Copy_Files(string srcFolder, string destFolder, string uExt, string[] ufilters)
        {
            bool copyAll = false;
            if (ufilters.Length < 1) copyAll = true;
            Dictionary<string, string> itmList = GetFilterList();
            List<string> foundItms = new List<string>();
            
            lblStatus.Text = "Listing all files that satisfy the filter criteria, please wait.......";
            lblStatus.Refresh();
            string[] files = Directory.GetFiles(srcFolder, uExt, SearchOption.AllDirectories);
            foreach (string uFile in files)
            {   string ufileName = Path.GetFileName(uFile);
                lblStatus.Text = "Checking file....." + ufileName;
                lblStatus.Refresh();
                if (!copyAll)
                {   bool blnCopy = false;
                    foreach (string uf in ufilters)
                    {   if (ufileName.ToUpper().Contains(uf.ToUpper()))
                        {   if (itmList.Count < 1)
                            {   blnCopy = true;
                                break; }
                            string basinNa = ufileName.Substring(0, 5).ToUpper();
                            if (itmList.ContainsKey(basinNa))
                            {   blnCopy = true;
                                foundItms.Add(basinNa);//marking as already copied.
                                break; } } }
                    if (!blnCopy) continue;
                }
                string destPath = destFolder + "\\" + ufileName;
                if (File.Exists(destPath)) continue;//do not overwrite.
                File.Copy(uFile, destPath,true);//overwrite the files.
            }
            string cOutFile = txtMissedItems.Text.Trim();
            StreamWriter csvOut = new StreamWriter(cOutFile);
            //remove found items from the collection.
            foreach (string itm in foundItms)
                itmList.Remove(itm);
            //Save the not found items.
            foreach (string basinName in itmList.Values)
                csvOut.WriteLine(basinName);
            csvOut.Close();
            lblStatus.Text = "";
            lblStatus.Refresh();
        }

        private void btnCopyFiles_Click(object sender, EventArgs e)
        {
            string srcDir = txtSrcFolder.Text.Trim();
            string uExt=txtExt.Text.Trim();
            string filterCriteria = txtFilter.Text.Trim();
            string[] ufilter=filterCriteria.Split(';');
            string destDir = txtDestFolder.Text.Trim();
            
            if (Directory.Exists(srcDir))
            {   //string folderpath = filepath.Substring(0, sPos);
                if (!Directory.Exists(destDir))
                    Directory.CreateDirectory(destDir);
                Copy_Files(srcDir, destDir,uExt, ufilter);
                MessageBox.Show("Copy process completed.");
            }
            else
                MessageBox.Show("This source directory does not exist.");
        }

        private Dictionary<string,string> GetFilterList()
        {
            Dictionary<string,string> filterList = new Dictionary<string,string>();
            string fileName = txtFilterNames.Text.Trim();
            if (!File.Exists(fileName)) return filterList;

            StreamReader csvFile = new StreamReader(txtFilterNames.Text.Trim());
            csvFile.ReadLine();
            while (!csvFile.EndOfStream)
            {   string itmName = csvFile.ReadLine();
                string[] itms = itmName.Split(',');
                if (itms.Length < 1) continue;
                string itm = itms[0].ToUpper();
                if (!filterList.ContainsKey(itm)) 
                    filterList.Add(itm, itm); }
            csvFile.Close();
            return filterList;
        }

        private void btnLoadSettings_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.InitialDirectory = Application.StartupPath;
            dlgOpen.Filter = "*.txt|*.txt";
            dlgOpen.FileName = string.Empty;
            dlgOpen.ShowDialog();
            string settingsName = dlgOpen.FileName;
            if (settingsName == string.Empty) return;
            //set parameters sequentially.
            StreamReader csvIn = new StreamReader(settingsName);
            /* Example input file.
                Source Folder,Y:\SrcFiles
                File Extension,*.inp
                Other Criteria,RTK
                Key Names for copy path,K:\KeyNamesToCopy.csv
                Save Files for missing,K:\FilesToCopy_missed.csv
                Destination Folder,K:\DestFolder
             */
            txtSrcFolder.Text = GetParameterValue(csvIn);
            txtExt.Text = GetParameterValue(csvIn);
            txtFilter.Text = GetParameterValue(csvIn);
            txtFilterNames.Text = GetParameterValue(csvIn);
            txtMissedItems.Text =GetParameterValue(csvIn);
            txtDestFolder.Text = GetParameterValue(csvIn);
            csvIn.Close();
        }

        private string GetParameterValue(StreamReader csvIn)
        {
            if (csvIn.EndOfStream) return string.Empty;
            string csvLine = csvIn.ReadLine();
            string[] itm = csvLine.Split(',');
            if (itm.Length < 1) return string.Empty;
            return itm[1];
        }

        private void btnSrcFolder_Click(object sender, EventArgs e)
        {
            dgDir.ShowNewFolderButton = true;
            DialogResult dlgR = dgDir.ShowDialog();
            if (dlgR == DialogResult.OK)
            {   string dirName = dgDir.SelectedPath;
                if (dirName != String.Empty)
                    txtSrcFolder.Text = dirName;
            }
        }

        private void btnDestFolder_Click(object sender, EventArgs e)
        {
            dgDir.ShowNewFolderButton = true;
            DialogResult dlgR = dgDir.ShowDialog();
            if (dlgR == DialogResult.OK)
            {   string dirName = dgDir.SelectedPath;
                if (dirName != String.Empty)
                    txtDestFolder.Text = dirName;}
        }
    }
}