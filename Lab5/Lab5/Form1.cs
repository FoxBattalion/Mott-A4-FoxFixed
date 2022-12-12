using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        int count = 1;
        
        const int maxCount = 3;

        //This constant is to be called whenever my name is needed//
        private const string PROGRAMMER = "Brandon-Cochran-Mott";

        //This fuction is used to generate and send random numers set between the values min and max//
        private int GetRandom(int min, int max)
        {
            Random rand = new Random();
            return rand.Next(min, max);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //this.Text =;//
            grpChoose.Hide();
            grpText.Hide();
            grpStats.Hide();
            txtCode.Focus();
            lblCode.Text= GetRandom(100000,200000).ToString();  
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(txtCode.Text == lblCode.Text) 
            { 
                grpChoose.Show();
                grpLogin.Enabled = false;
            }
            else if (count == maxCount)
            {
                MessageBox.Show(maxCount+" attempt to login\n Account Locked - Closing Program", PROGRAMMER, MessageBoxButtons.OK);
                this.Close();
            }
            else if(txtCode.Text != lblAuthCode.Text) 
            {
                MessageBox.Show(count+" incorrect code(s) entered\n Try Again - only 3 attempts allowed",PROGRAMMER,MessageBoxButtons.OK);
                txtCode.SelectAll();
                txtCode.Focus();
                ++count;
            }

        }
        //This is a control that clears the Text group box//
        private void ResetTextGrp()
        {
            txtString1.Clear();
            txtString2.Clear();
            lblResults.Text = "";
        }
        //This is a control that clears the Stats group box//
        private void ResetStatsGrp()
        {
            lblBoxSum.Text= "";
            lblMeanBox.Text= "";
            lblOddBox.Text = "";
        }
        //This function is a control to be placed in the Radio Buttons Text and Stats//
        private void SetupOption()
        {
            if (radText.Checked) 
            {
                grpText.Show();
                grpStats.Hide();
                this.AcceptButton = btnJoin;
                this.CancelButton = btnReset;

            }
            else if (radStats.Checked) 
            {
                grpStats.Show();
                grpText.Hide();
                this.AcceptButton = btnGenerate;
                this.CancelButton= btnClear;
            }
            
        }

        //This is the Radio Button Text//
        private void radText_CheckedChanged(object sender, EventArgs e)
        {
            SetupOption();
        }

        //This is the Radio Button Stats//
        private void radStats_CheckedChanged(Object sender, EventArgs e) 
        {
            SetupOption();
        }

        //This is the Reset button in Group Box Text//
        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetTextGrp();
        }
        //This is the Clear button in Group Box Stats//
        private void btnClear_Click(object sender, EventArgs e)
        {
            ResetStatsGrp();
        }

        //This function swaps strings//
        private void Swap(ref string string1, ref string string2) 
        {
            string temp = string1;
            string1 = string2;
            string2 = temp;
        }

        //This function checks if valid data has been inputted//
        private bool CheckInput() 
        {
            if (txtString1.Text=="" && txtString2.Text=="") 
            {
                return false;
            }
            return true;
        } 
        
        //Swaps text in txtString1 and txtstring2//
        private void chkSwap_CheckedChanged(object sender, EventArgs e) 
        {
            string text1 = txtString1.Text;
            string text2 = txtString2.Text;
            if (CheckInput())
            { 
                Swap(ref text1, ref text2);
                txtString1.Text = text1;
                txtString2.Text = text2;
            }
        }
        //Displays and joins the data inputted in text boxes//
        private void btnJoin_Click(object sender, EventArgs e)
        {
            if (CheckInput()) 
            {
                lblResults.Text = "First String = " + txtString1.Text + "\n Second String = " + txtString2.Text + "\n Joined = " + txtString1.Text + "-->" + txtString2.Text;
            }

        }
        //Counts the amount of characters in each string then displays that data//
        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            if (CheckInput()) 
            { 
                lblResults.Text = "First String = " + txtString1.Text + "\n Characters = " + txtString1.TextLength + "\n Second String = " + txtString2.Text + "\n Characters = " + txtString2.TextLength;
            }
        }
        //This button generates a list of random numbers then runs calculations//
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            lstNumbers.Items.Clear();
            Random random= new Random(733);
            for (int i = 0; i <= numUDHowMany.Value; i++)
            {
                int genRandNum = random.Next(1000, 5000);
                lstNumbers.Items.Add(genRandNum.ToString());
            }
        }
    }
}
