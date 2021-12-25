using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices; // important
using System.Windows.Forms;
using MySql.Data.MySqlClient;/*MySqlConnection connexion = new MySqlConnection("database=gestalone; server=localhost; user id=root; pwd=");*/

namespace GestAlone
{
    public partial class FormConnexion : Form 
    {

        [DllImport("Gdi32.dll", EntryPoint="CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );
        public FormConnexion()
        {
            InitializeComponent();
            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20)); 
        }

        private void FormConnexion_Load(object sender, EventArgs e)
        {
            this.AcceptButton = btnConnexion; 

        }

       

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void tbIdGerant_Enter(object sender, EventArgs e)
        {
            tbIdGerant.Text = "";
            tbIdGerant.ForeColor = Color.Black;
            pnlUnderIdGerant.BackColor = Color.Black;

            lblMsgErreurConn.Text = "";
        }

        private void tbIdGerant_Leave(object sender, EventArgs e)
        {
            if (tbIdGerant.Text =="")
            {
                tbIdGerant.Text = "Identifiant";
                tbIdGerant.ForeColor = Color.ForestGreen;
                pnlUnderIdGerant.BackColor = Color.ForestGreen;
            }
        }

        private void tbMdpGerant_Enter(object sender, EventArgs e)
        {
            tbMdpGerant.Text = "";
            tbMdpGerant.PasswordChar = '*';
            tbMdpGerant.ForeColor = Color.Black;
            pnlUnderMdpGerant.BackColor = Color.Black;
            lblMsgErreurConn.Text = "";
        }

     

        private void tbMdpGerant_Leave(object sender, EventArgs e)
        {
            if (tbMdpGerant.Text =="")
            {
                tbMdpGerant.PasswordChar='\0';
                tbMdpGerant.Text = "Mot De Passe";
                tbMdpGerant.ForeColor = Color.ForestGreen;
                pnlUnderMdpGerant.BackColor = Color.ForestGreen;
            }
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            tbIdGerant.Text = "Identifiant";
            tbIdGerant.ForeColor = Color.ForestGreen;
            pnlUnderIdGerant.BackColor = Color.ForestGreen;

            tbMdpGerant.PasswordChar = '\0';        
            tbMdpGerant.Text = "Mot De Passe";
            tbMdpGerant.ForeColor = Color.ForestGreen;
            pnlUnderMdpGerant.BackColor = Color.ForestGreen;

            lblMsgErreurConn.Text = "";
        }

        private void btnConnexion_Click(object sender, EventArgs e)
        {
            // connexion de l'administrateur :
            /**
             * a => identifiant
             * b => Mot De Passe
             * c => idGerant
             * d => mdpGerant
             */
            string a, b, c, d;
            a = "Identifiant";
            b = "Mot De Passe";
            c = tbIdGerant.Text.Trim();
            d = tbMdpGerant.Text.Trim();
            if (a == c && b == d)
            {
                lblMsgErreurConn.Text = "Remplissez le formulaire.";
            }else if( a == c && b != d)
            {
                lblMsgErreurConn.Text = "     Saisissez l'identifiant.";

            }else if(a!=c && b == d)
            {
                lblMsgErreurConn.Text = "Saisissez le mot de passe.";
            }
            else
            { 
                // on établi la connexion à la base de données :
                string cs = @"server=localhost;userid=root;password=;database=gestalonebis";
                MySqlConnection conn = null;
                MySqlDataReader rdr = null;

                try
                {

                    conn = new MySqlConnection(cs);
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT * from gerant where loginGerant=@a and mdpGerant =@b";
                    cmd.Parameters.AddWithValue("@a", c);
                    cmd.Parameters.AddWithValue("@b", d);
                   
                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        LogInfo.UserID = rdr.GetInt32(0);
                        this.Hide();
                        Main unMain = new Main();
                        unMain.Show();
                    }
                    else
                    {
                        lblMsgErreurConn.Text = " Erreur De Connexion.";
                    }
                }
                catch (MySqlException exp)
                {
                    MessageBox.Show(exp.Message);
                }
                finally
                {
                    if (rdr != null)
                    {
                        rdr.Close();
                    }
                    if (conn != null)
                    {
                        conn.Close();
                    }
                }
               

            }

        }

       

       
    }
}
