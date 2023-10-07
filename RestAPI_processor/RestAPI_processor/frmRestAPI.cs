using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestAPI_processor
{
    public partial class frmRestAPI : Form
    {
        public frmRestAPI()
        {
            InitializeComponent();
            txtURL.Text = "https://api.census.gov/data/2017/acs/acs1/profile";
            txtWebPage.Text = "?get=DP02_0001E,NAME&for=place:*&in=state:*";
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            string uURL = txtURL.Text;
            string uRoute = txtWebPage.Text;
            clsRestAPI testAPI = new clsRestAPI(uURL, uRoute);

            string uResult = testAPI.makeRestAPI_request();
            textBox1.Text = uResult;
            displayContent(uResult);
        }

        private void displayContent(string uTxt)
        {
            uTxt = uTxt.Replace("[", "");
            uTxt = uTxt.Replace("]", "");
            uTxt = uTxt.Replace("\"", "");
            char[] c = new char[] {'\n' };
            string[] uData = uTxt.Split(c);

            c[0] = ',';
            dgView.Rows.Clear();
            for (int i=1;i<uData.Length;i++)
            {
                string[] itms = uData[i].Split(c);
                dgView.Rows.Add(itms);
            }
        }
    }
}
