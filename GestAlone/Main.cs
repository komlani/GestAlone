using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices; // important pour les bord arrondis :
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;

namespace GestAlone
{
    public partial class Main : Form
    {
       
        string cs = @"server=localhost;userid=root;password=;database=gestalonebis";
        MySqlConnection conn = null;
        MySqlDataReader rdr = null;
        int campagneActives = 0;

        #region : déclaraition des variables d'impression
        StringFormat strFormat; //Used to format the grid rows.
        ArrayList arrColumnLefts = new ArrayList();//Used to save left coordinates of columns
        ArrayList arrColumnWidths = new ArrayList();//Used to save column widths
        int iCellHeight = 0; //Used to get/set the datagridview cell height
        int iTotalWidth = 0; //
        int iRow = 0;//Used as counter
        bool bFirstPage = false; //Used to check whether we are printing first page
        bool bNewPage = false;// Used to check whether we are printing a new page
        int iHeaderHeight = 0; //Used for the header height
        #endregion

        
        /* mes methodes*/

             // virification si une campagne existe déjà
             public void verifCA()
        {
            try
            {
                // verifier si une campagne active existe déja :
                conn = new MySqlConnection(cs);
                conn.Open();
                string stm = "SELECT numCA FROM campagne_agricole where statutArchCA = 0";
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                campagneActives = Convert.ToInt32(cmd.ExecuteScalar());
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }

        }

             // populate dgvAA :
             public void popDgvAA()
        {
            dgvAA.Rows.Clear();
            // requete de scelection de toutes les AA :
            try
            {
                conn = new MySqlConnection(cs);
                conn.Open();
                string stm = "SELECT * FROM activite_agricole where statutActAgri = 1 and statutArchActAgri = 0 order by libActAgri";
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                rdr = cmd.ExecuteReader();
                // population of the dgv:
                while (rdr.Read())
                {
                    string numAA = rdr.GetInt32(0).ToString();
                    string libAA = rdr.GetString(1);
                     dgvAA.Rows.Add(
                        new object[] 
                        { 
                            numAA,
                            libAA,
                            "Modifier",
                            "Supprimer"
                        }

                     );
                }
                 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
             public void popDgvEV()
            {
                dgvEV.Rows.Clear();
                // requete de selection de toutes les AA :
                try
                {
                    conn = new MySqlConnection(cs);
                    conn.Open();
                    string stm = "SELECT * FROM espece_vegetale where statutEspVeg = 1 and statutArchEspVeg = 0 order by libEspVeg";
                    MySqlCommand cmd = new MySqlCommand(stm, conn);
                    rdr = cmd.ExecuteReader();
                   
                    // population of the dgv:
                    while (rdr.Read())
                    {
                        string numEV = rdr.GetInt32(0).ToString();
                        string libEV = rdr.GetString(1);
                        string prixEV = rdr.GetInt32(2).ToString();
                        dgvEV.Rows.Add(
                            new object[] 
                            { 
                                numEV,
                                libEV,
                                prixEV,
                                "Modifier",
                                "Supprimer"
                            }

                        );
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
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
             public void popDgvGestDep()
             {
                 dgvGestDep.Rows.Clear();

                 // insertion :
                 try
                 {
                     conn = new MySqlConnection(cs);
                     conn.Open();
                     string stm = "SELECt depense.numDep as a, activite_agricole.numActAgri as b, depense.dateEnregDep as c, activite_agricole.libActAgri as d, depense.descDep as e, depense.montantDep as f from depense inner join activite_agricole on depense.numActAgri = activite_agricole.numActAgri where depense.statutDep = 1 and statutArchDep = 0 order by depense.dateEnregDep desc";
                     MySqlCommand cmd = new MySqlCommand(stm, conn);
                     rdr = cmd.ExecuteReader();

                     // population of the dgv:
                     while (rdr.Read())
                     {
                         string numDep = rdr.GetInt32(0).ToString();
                         string numActAgri = rdr.GetString(1);
                         string dateEnregDep = rdr.GetDateTime(2).ToString();
                         string libActAgri = rdr.GetString(3);
                         string descDep = rdr.GetString(4);
                         string montantDep = rdr.GetInt32(5).ToString();
                         
                         dgvGestDep.Rows.Add(
                             new object[] 
                            { 
                                numDep,
                                numActAgri,
                                dateEnregDep,
                                libActAgri,
                                descDep,
                                montantDep,
                                "Modifier",
                                "Supprimer"
                            }

                         );
                     }

                 }
                 catch (Exception ex)
                 {
                     MessageBox.Show(ex.Message);
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
             public void popDgvGestRec()
             {
                 dgvGestRec.Rows.Clear();

                 // insertion :
                 try
                 {
                     conn = new MySqlConnection(cs);
                     conn.Open();
                     string stm = "SELECT espece_vegetale.numEspVeg as a, produire.dateRecolte as b, espece_vegetale.libEspVeg as c, produire.qtteRecolte as d from produire INNER JOIN espece_vegetale ON produire.numEspVeg = espece_vegetale.numEspVeg WHERE produire.statutRec = 1 and produire.statutArchRec = 0 order by produire.dateRecolte desc";
                     MySqlCommand cmd = new MySqlCommand(stm, conn);
                     rdr = cmd.ExecuteReader();

                     // population of the dgv:
                     while (rdr.Read())
                     {
                         string numEspVeg = rdr.GetInt32(0).ToString();
                         string dateRec = rdr.GetDateTime(1).ToString();
                         string libEspVegetale = rdr.GetString(2);
                         string qtteRec = rdr.GetInt32(3).ToString();
                         
                         dgvGestRec.Rows.Add(
                             new object[] 
                            { 
                                numEspVeg,
                                dateRec,
                                libEspVegetale,
                                qtteRec,
                                "Modifier",
                                "Supprimer"
                            }

                         );
                     }

                 }
                 catch (Exception ex)
                 {
                     MessageBox.Show(ex.Message);
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
             public void popDgv5derniereRecoltes()
             {
                 

                 // on recueil le numéro de la campagne agricole : 
                 try
                 {
                     conn = new MySqlConnection(cs);
                     conn.Open();
                     string stm = "SELECT max(numCA) FROM campagne_agricole";
                     MySqlCommand cmd = new MySqlCommand(stm, conn);
                     LogInfo.caID = Convert.ToInt32(cmd.ExecuteScalar());
                     //MessageBox.Show(LogInfo.caID.ToString());
                 }
                 catch (Exception ex)
                 {
                     MessageBox.Show(ex.Message);
                 }
                 finally
                 {
                     if (conn != null)
                     {
                         conn.Close();
                     }
                 } 
                 


                 // selection des données à peupler le datagridview : 

                 //purge de la datagridview : 
                 dgv5derniereRecoltes.Rows.Clear();

                 try
                 {
                     conn = new MySqlConnection(cs);
                     conn.Open();

                     MySqlCommand cmd = new MySqlCommand();
                     cmd.Connection = conn;
                     cmd.CommandText = "select produire.dateRecolte as a, espece_vegetale.libEspVeg as b,produire.qtteRecolte as c from produire inner join espece_vegetale on produire.numEspVeg = espece_vegetale.numEspVeg where produire.numCA = @a and produire.statutRec = 1 and produire.statutArchRec = 0 order by produire.dateRecolte desc limit 5 offset 0;";
                     cmd.Parameters.AddWithValue("@a", LogInfo.caID);

                     rdr = cmd.ExecuteReader();

                     while (rdr.Read())
                     {
                         string dateRec = rdr.GetDateTime(0).ToString();
                         string libEspVegetale = rdr.GetString(1);
                         string qtteRec = rdr.GetInt32(2).ToString();

                         dgv5derniereRecoltes.Rows.Add(
                             new object[] 
                            { 
                                dateRec,
                                libEspVegetale,
                                qtteRec
                            }

                         );
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
             public void popDgv5derniereDepenses()
             {

                 // purge de la gdv : 
                 dgv5derniereDepenses.Rows.Clear();

                 // selection des objets devant servir à peupler la dgv : 
                 try
                 {
                     conn = new MySqlConnection(cs);
                     conn.Open();

                     MySqlCommand cmd = new MySqlCommand();
                     cmd.Connection = conn;
                     cmd.CommandText = "select depense.dateEnregDep as a, activite_agricole.libActAgri as b, depense.descDep as c, depense.montantDep as d from depense inner join activite_agricole on depense.numActAgri = activite_agricole.numActAgri where depense.numCA = @a and depense.statutDep = 1 and depense.statutArchDep = 0 order by depense.dateEnregDep desc limit 5 OFFSET 0";
                     cmd.Parameters.AddWithValue("@a", LogInfo.caID);

                     rdr = cmd.ExecuteReader();

                     while (rdr.Read())
                     {
                         string a = rdr.GetDateTime(0).ToString();
                         string b = rdr.GetString(1);
                         string c = rdr.GetString(2);
                         string d = rdr.GetInt32(3).ToString();

                         dgv5derniereDepenses.Rows.Add(
                             new object[] 
                            { 
                                a,b,c,d+" Fr Cfa" 
                            }

                         );
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

            // populate cb :
             public void popCbGestDep()
             {
                 // requete se selection des activité agricoles : 
                 try
                 {
                     conn = new MySqlConnection(cs);
                     conn.Open();

                     string stm = "SELECT * FROM activite_agricole where statutActAgri = 1 and statutArchActAgri = 0 order by libActAgri";
                     MySqlCommand cmd = new MySqlCommand(stm, conn);
                     rdr = cmd.ExecuteReader();
                     List<ActAgri> list = new List<ActAgri>();
                    
                     while (rdr.Read())
                     {
                         list.Add(new ActAgri() { numActAgri = rdr.GetInt32(0), libActAgri = rdr.GetString(1) });
                     }
                     cbActAgri.DataSource = list;
                     cbActAgri.ValueMember = "numActAgri";
                     cbActAgri.DisplayMember = "libActAgri";
                 }
                 catch (MySqlException ex)
                 {
                     MessageBox.Show(ex.Message);

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
             public void popCbGestRec()
             {
                 // requete se selection des activité agricoles : 
                 try
                 {
                     conn = new MySqlConnection(cs);
                     conn.Open();

                     string stm = "SELECT * FROM espece_vegetale where statutEspVeg = 1 and statutArchEspVeg = 0 order by libEspVeg";
                     MySqlCommand cmd = new MySqlCommand(stm, conn);
                     rdr = cmd.ExecuteReader();
                     List<EspVeg> list = new List<EspVeg>();

                     while (rdr.Read())
                     {
                         list.Add(new EspVeg() { numEspVeg = rdr.GetInt32(0), libEspVeg = rdr.GetString(1) });
                     }
                     cbEspVeg.DataSource = list;
                     cbEspVeg.ValueMember = "numEspVeg";
                     cbEspVeg.DisplayMember = "libEspVeg";
                 }
                 catch (MySqlException ex)
                 {
                     MessageBox.Show(ex.Message);

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

            // populate tb : 
             public void popTbTotalDep()
             {
                 // selection de l'objet : 
                 verifCA();
                
                 if (campagneActives != 0)
                 {
                     
                        // on fait la selection et on affiche le total des dépenses : 
                         try
                         {
                            conn = new MySqlConnection(cs);
                            conn.Open();

                            MySqlCommand cmd = new MySqlCommand();
                            cmd.Connection = conn;
                            cmd.CommandText = "select sum(montantDep) as a from depense where numCA = @a";
                            cmd.Parameters.AddWithValue("@a",LogInfo.caID);
                   
                            rdr = cmd.ExecuteReader();

                            if (rdr.Read())
                            {
                                if (rdr.IsDBNull(0))
                                {
                                   // objet vide : 
                                    lblDepensesEffectuees.Text = " 0 Fr Cfa ";
                                }
                                else
                                {
                                   // objet non vide : 
                                    lblDepensesEffectuees.Text = " "+ rdr.GetInt32(0).ToString()+" Fr Cfa";
                                } 
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
                 else
                 {
                     lblDepensesEffectuees.Text = " 0 Fr Cfa ";
                 }
                 campagneActives = 0;

             }
             public void popTbTotalRecettes()
             {
                 verifCA();

                 if (campagneActives != 0)
                 {
                     // séléction de la recette proble : 
                     try
                     {
                         conn = new MySqlConnection(cs);
                         conn.Open();

                         MySqlCommand cmd = new MySqlCommand();
                         cmd.Connection = conn;
                         cmd.CommandText = "select sum(espece_vegetale.puEspVeg*produire.qtteRecolte) as a from produire INNER JOIN espece_vegetale on produire.numEspVeg = espece_vegetale.numEspVeg where produire.statutRec = 1 and produire.statutArchRec = 0 and produire.numCA =@a";
                         cmd.Parameters.AddWithValue("@a", LogInfo.caID);

                         rdr = cmd.ExecuteReader();

                         if (rdr.Read())
                         {
                             if (rdr.IsDBNull(0))
                             {
                                 // objet vide : 
                                 lblRecettesProbable.Text = " 0 Fr Cfa ";
                             }
                             else
                             {
                                 // objet non vide : 
                                 lblRecettesProbable.Text = " " + rdr.GetInt32(0).ToString() + " Fr Cfa";
                             }
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
                 else
                 {
                     lblRecettesProbable.Text = " 0 Fr Cfa ";
                 }

             }
            // procedur cameleon
            public void cameleon()
            {
                btnTablBord.BackColor = Color.Transparent;
                btnTablBord.ForeColor = Color.White;

                btnAjoutEV.BackColor = Color.Transparent;
                btnAjoutEV.ForeColor = Color.White;


                btnAActAgri.BackColor = Color.Transparent;
                btnAActAgri.ForeColor = Color.White;

                btnGestDep.BackColor = Color.Transparent;
                btnGestDep.ForeColor = Color.White;

                btnGestRec.BackColor = Color.Transparent;
                btnGestRec.ForeColor = Color.White;

                btnArchives.BackColor = Color.Transparent;
                btnArchives.ForeColor = Color.White;


            }
            
            // procedure cacheCache :
            public void cacheCache()
            {
                pnlTabBord.Visible = false;
                pnlAjoutAA.Visible = false;
                pnlAjouEV.Visible = false;
                pnlGestDep.Visible = false;
                pnlGestRec.Visible = false;

            }
            // verification doublons : 
            public bool duplicated2StringFound(string uneTable, string unLib, string unAutreLib, string unStatut, string unInput, string unAutreInput, string unArch)
            {
                // declaration des variables locales : 
                bool trouver = false;
                unInput = unInput.Trim();
                unInput = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(unInput.ToLower());
              
                unAutreInput = unAutreInput.Trim();
                // requete de selection des elements dans la table précisée :
                try
                {
                    conn = new MySqlConnection(cs);
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "select count(" + unLib + ") from " + uneTable + " where " + unStatut + "=@a and " + unLib + "= @b and "+unAutreLib+" = @c and "+unArch+"=@d";
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@a", "1");
                    cmd.Parameters.AddWithValue("@b", unInput);
                    cmd.Parameters.AddWithValue("@c", Convert.ToInt32(unAutreInput));
                    cmd.Parameters.AddWithValue("@d", "0");
                    int valeurCount = Convert.ToInt32(cmd.ExecuteScalar());
                   
                    if (valeurCount > 0)
                    {
                        trouver = true;
                    }

                }
                catch (MySqlException exp)
                {
                    MessageBox.Show(exp.Message);
                }
                finally
                {
                    if (conn != null)
                    {
                        conn.Close();
                    }
                }
                return trouver;

            }
            public bool duplicatedStringFound(string uneTable, string unLib, string unStatut, string unInput, string unArch)
             {
                 // declaration des variables locales : 
                 bool trouver = false;
                 unInput = unInput.Trim();
                 unInput = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(unInput.ToLower());
                 // requete de selection des elements dans la table précisée :
                 try
                 {
                     conn = new MySqlConnection(cs);
                     conn.Open();
                    
                     MySqlCommand cmd = new MySqlCommand();
                     cmd.Connection = conn;
                     cmd.CommandText = "select count("+unLib+") from "+uneTable+" where "+unStatut+"=@a and "+unLib+"= @b and "+unArch+" = @c";
                     cmd.Prepare();
                     cmd.Parameters.AddWithValue("@a","1");
                     cmd.Parameters.AddWithValue("@b", unInput);
                     cmd.Parameters.AddWithValue("@c", "0");
                     int valeurCount = Convert.ToInt32(cmd.ExecuteScalar());

                     if (valeurCount > 0 )
                     {
                         trouver = true;
                     }
                    
                 }
                 catch (MySqlException exp)
                 {
                     MessageBox.Show(exp.Message);
                 }
                 finally
                 {
                     if (conn != null)
                     {
                         conn.Close();
                     }
                 }
                 return trouver;
             }
             
        /* mes methodes*/
            

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );

        public Main()
        {
            InitializeComponent();
            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20)); 

        }

        private void Main_Load(object sender, EventArgs e)
        {
            // accept buttons :
            this.AcceptButton = btnAjouAA;
            //this.AcceptButton = btnAjouEV;
            // affichage du tableau de bord au démarrage de l'appication :
            cacheCache();
            pnlTabBord.Visible = true;          
        }
        private void pbCloseMain_Click(object sender, EventArgs e)
        {
            this.Close();
            LogInfo.caID = 0;
        }
        private void pbMinimizeMain_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void btnTablBord_Click(object sender, EventArgs e)
        {
            cameleon(); // appel de la methode hide and show pnls.
            btnTablBord.BackColor = Color.White;
            btnTablBord.ForeColor = Color.Black;

            // hide and show elements on clicks :
            cacheCache();
            pnlTabBord.Visible = true;
        }
        private void btnAjoutEV_Click(object sender, EventArgs e)
        {
            cameleon(); // appel de la methode hide and show pnls.
            btnAjoutEV.BackColor = Color.White;
            btnAjoutEV.ForeColor = Color.Black;
            // hide and show elements on clicks :
            cacheCache();
            pnlAjouEV.Visible = true;
            // outofocus tb :

        }
        private void btnAActAgri_Click(object sender, EventArgs e)
        {
            cameleon(); // appel de la methode hide and show pnls.
            btnAActAgri.BackColor = Color.White;
            btnAActAgri.ForeColor = Color.Black;

            // hide and show elements on clicks :
            cacheCache();
            pnlAjoutAA.Visible = true;


        }
        private void btnGestDep_Click(object sender, EventArgs e)
        {
            cameleon(); // appel de la methode hide and show pnls.
            btnGestDep.BackColor = Color.White;
            btnGestDep.ForeColor = Color.Black;

            // hide and show elements on clicks :
            cacheCache();
            pnlGestDep.Visible = true;
        }
        private void btnGestRec_Click(object sender, EventArgs e)
        {
            cameleon(); // appel de la methode hide and show pnls.
            btnGestRec.BackColor = Color.White;
            btnGestRec.ForeColor = Color.Black;

            // hide and show elements on clicks :
            cacheCache();
            pnlGestRec.Visible = true;
        }
        private void btnArchives_Click(object sender, EventArgs e)
        {
            cameleon();
            btnArchives.BackColor = Color.White;
            btnArchives.ForeColor = Color.Black;
            cacheCache();
            // on cache celui-ci et on montre la fenêtre des archives :
            this.Hide();
            Archives unArchive = new Archives();
            unArchive.Show();
        }
        private void btnActiverCampagne_Click(object sender, EventArgs e)
        {
            verifCA();
            // si 0 on active sinon on affiche message d'erreur :
            if (campagneActives == 0)
            {
                // activation d'une nouvelle campagne:
                DateTime today = DateTime.Today;
                string codeCA =today.Year.ToString();
                // on va selectionner le max id :
                try
                {
                    conn = new MySqlConnection(cs);
                    conn.Open();
                    string stm = "select max(numCA) from campagne_agricole";
                    MySqlCommand cmd = new MySqlCommand(stm, conn);
                    int trouver = Convert.ToInt32(cmd.ExecuteScalar());
                    codeCA += "-" + trouver.ToString();
                   // MessageBox.Show(codeCA);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    if (conn != null)
                    {
                        conn.Close();
                    }
                } 

                // insertion dans la base de donnees :
                try
                {
                    conn = new MySqlConnection(cs);
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "insert into campagne_agricole(dateCA, codeCA, numGerant) values(@a, @b, @c)";
                    cmd.Prepare();

                    cmd.Parameters.AddWithValue("@a", today);
                    cmd.Parameters.AddWithValue("@b", codeCA);
                    cmd.Parameters.AddWithValue("@c", LogInfo.UserID);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show(" Une Nouvelle Campagne est Activée.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    if (conn != null)
                    {
                        conn.Close();
                    }
                } 
               
            }
            else
            {
                // message campagne existe :
                MessageBox.Show("Veillez d'abord clôturer la campagne en cours.");
            }

        }
        private void btnCloturerCampagne_Click(object sender, EventArgs e)
        {
            int caExiste = 0;
            // on teste si CA est active : 
            try
            {
                
                conn = new MySqlConnection(cs);
                conn.Open();
                string stm = "SELECT numCA FROM campagne_agricole where statutArchCA = 0";
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                caExiste = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }


            if (caExiste == 0)
            {
                // msg aucune camp à clôturer : 
                MessageBox.Show(" Aucune Campagne à clôturer. Veillez en Démarrer une SVP ! ");
            }
            else
            {
                // on teste si depense et produire possedent des enrégistrements avec la CA en cours : 

                // liste des booléens : 
                bool trouverDep = false, trouverProd = false;

                // teste de dépense : 
                try {
                   
                    // MessageBox.Show(LogInfo.caID.ToString());
                    conn = new MySqlConnection(cs);
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "select count(depense.numCA) from depense INNER join campagne_agricole ON depense.numCA = campagne_agricole.numCA where campagne_agricole.numCA = @a";
                    cmd.Parameters.AddWithValue("@a", LogInfo.caID);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        int temp =  rdr.GetInt32(0);
                        if (temp != 0)
                        {
                            trouverDep = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Une erreur s'est produite.");
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

                // teste de produire : 
                try
                {

                    // MessageBox.Show(LogInfo.caID.ToString());
                    conn = new MySqlConnection(cs);
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT count(produire.numCA) from produire inner join campagne_agricole on produire.numCA = campagne_agricole.numCA where campagne_agricole.numCA = @a";
                    cmd.Parameters.AddWithValue("@a", LogInfo.caID);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        int temp = rdr.GetInt32(0);
                        if (temp != 0)
                        {
                            trouverProd = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Une erreur s'est produite.");
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
            
                // teste du resultat des teste : 

                if (trouverDep == false || trouverProd == false)
                {
                    // msg voulez-vous quand-même continuer?
                    if (MessageBox.Show("Il semble que cette Campagne Agricole n'a pas assez d'enrégistrement. Voulez-vous Quand même continuer?", "Confirmation De Clôture", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        // archivage etape par étape : 
                        // dépense : 
                        try
                        {
                            conn = new MySqlConnection(cs);
                            conn.Open();

                            MySqlCommand cmd = new MySqlCommand();
                            cmd.Connection = conn;
                            cmd.CommandText = "update depense set statutArchDep = 1 where numCA = @a";
                            cmd.Prepare();
                            cmd.Parameters.AddWithValue("@a", LogInfo.caID);
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
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

                        // produire: 
                        try
                        {
                            conn = new MySqlConnection(cs);
                            conn.Open();

                            MySqlCommand cmd = new MySqlCommand();
                            cmd.Connection = conn;
                            cmd.CommandText = "update produire set statutArchRec = 1 where numCA = @a";
                            cmd.Prepare();
                            cmd.Parameters.AddWithValue("@a", LogInfo.caID);
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
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

                        // campagne agricole :  
                        try
                        {
                            conn = new MySqlConnection(cs);
                            conn.Open();

                            MySqlCommand cmd = new MySqlCommand();
                            cmd.Connection = conn;
                            cmd.CommandText = "UPDATE campagne_agricole SET statutArchCA = 1 where numCA = @a";
                            cmd.Prepare();
                            cmd.Parameters.AddWithValue("@a", LogInfo.caID);
                            cmd.ExecuteNonQuery();

                            MessageBox.Show(" La campagne agricole a été bien archivée.");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
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
                else
                {
                    // archivage avec les jointures
                    try
                    {
                        conn = new MySqlConnection(cs);
                        conn.Open();

                        MySqlCommand cmd = new MySqlCommand();
                        cmd.Connection = conn;
                        cmd.CommandText = " update produire inner join espece_vegetale on produire.numEspVeg = espece_vegetale.numEspVeg INNER join campagne_agricole on produire.numCA = campagne_agricole.numCA SET produire.statutArchRec = 1, campagne_agricole.statutArchCA = 1, espece_vegetale.statutArchEspVeg = 1 where campagne_agricole.numCA = @a";
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@a", LogInfo.caID);
                        cmd.ExecuteNonQuery();
                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
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

                    // archivage des dépenses et des activitées agricoles :  
                    try
                    {
                        conn = new MySqlConnection(cs);
                        conn.Open();

                        MySqlCommand cmd = new MySqlCommand();
                        cmd.Connection = conn;
                        cmd.CommandText = "update depense inner join campagne_agricole on depense.numCA = campagne_agricole.numCA INNER join activite_agricole on depense.numActAgri = activite_agricole.numActAgri set activite_agricole.statutArchActAgri = 1, depense.statutArchDep = 1 where campagne_agricole.numCA = @a";
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@a", LogInfo.caID);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show(" La campagne agricole a été bien archivée.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
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
        private void Main_Activated(object sender, EventArgs e)
        {
            int campExiste = 0;
            //## debut requete label campagne :
            // requete pour voir si une campagne est active :
            try
            {
                // verifier si une campagne active existe déja :
                conn = new MySqlConnection(cs);
                conn.Open();
                string stm = "SELECT count(*) FROM campagne_agricole where statutArchCA = 0";
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                campExiste = Convert.ToInt32(cmd.ExecuteScalar());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }

            // si oui, on affiche rien, si oui on concatene :
            if (campExiste == 0)
            {
                lblCampagne.Text = "";
                cardAjouEV.Visible = false;
                dgvEV.Visible = false;
                dgvAA.Visible = false;
                bunifuCards1.Visible = false;
                dgvGestRec.Visible = false;
                bunifuCards3.Visible = false;
                bunifuCards2.Visible = false;
                dgvGestDep.Visible = false;
                dgv5derniereRecoltes.Visible = false;
                dgv5derniereDepenses.Visible = false;
                label1.Visible = false;
                label2.Visible = false;


                lblMsgActivationCA1.Visible = true;
                lblMsgActivationCA2.Visible = true;
                lblMsgActivationCA3.Visible = true;
                lblMsgActivationCA4.Visible = true;
                lblMsgActivationCA5.Visible = true;
                lblMsgDep.Visible = false;
                lblMsgEv.Visible = false;
                // disable e button ====>
            }
            else
            {
                // on fait la requete de selection de label :
                try
                {
                    // message pour le label du header :
                    conn = new MySqlConnection(cs);
                    conn.Open();
                    string stm = "SELECT * FROM campagne_agricole order by numCA  desc limit 1 offset 0";
                    MySqlCommand cmd = new MySqlCommand(stm, conn);
                    rdr = cmd.ExecuteReader();
                    rdr.Read();
                     LogInfo.caID = rdr.GetInt32(0);
                     string test = rdr.GetString(2);
                    lblCampagne.Text = " Campagne Agricole N° " + test; 
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
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

                // on teste si ce ca a une espece vegetale : 
                int temp = 0;
                try
                {
                    // verifier si une campagne active existe déja :
                    conn = new MySqlConnection(cs);
                    conn.Open();
                    string stm = "SELECT count(numEspVeg) from espece_vegetale where statutEspVeg = 1 and statutArchEspVeg = 0";
                    MySqlCommand cmd = new MySqlCommand(stm, conn);
                    temp = Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    if (conn != null)
                    {
                        conn.Close();
                    }
                }

                if (temp > 0)
                {
                    // on affiche le cb : 
                    dgvGestRec.Visible = true;
                    bunifuCards3.Visible = true;
                    lblMsgEv.Visible = false;
                }
                else
                {
                    dgvGestRec.Visible = false;
                    bunifuCards3.Visible = false;
                    lblMsgEv.Visible = true;       
                }

                // on vérifie si ca a une activité agricole : 
                int temp2 = 0;
                try
                {
                    // verifier si une campagne active existe déja :
                    conn = new MySqlConnection(cs);
                    conn.Open();
                    string stm = "select COUNT(numActAgri) FROM activite_agricole where statutActAgri = 1 and statutArchActAgri = 0";
                    MySqlCommand cmd = new MySqlCommand(stm, conn);
                    temp2 = Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    if (conn != null)
                    {
                        conn.Close();
                    }
                }

                if (temp2 > 0)
                {
                    // on affiche le cb : 
                    bunifuCards2.Visible = true;
                    dgvGestDep.Visible = true;
                    lblMsgDep.Visible = false;
                }
                else
                {
                    bunifuCards2.Visible = false;
                    dgvGestDep.Visible = false;
                    lblMsgDep.Visible = true;
                }
               
             // on réaffiche tous les autres objets : 
                cardAjouEV.Visible = true;
                dgvEV.Visible = true;
                dgvAA.Visible = true;
                bunifuCards1.Visible = true;
                
            
                dgv5derniereRecoltes.Visible = true;
                dgv5derniereDepenses.Visible = true;
                label1.Visible = true;
                label2.Visible = true;

                lblMsgActivationCA1.Visible = false;
                lblMsgActivationCA2.Visible = false;
                lblMsgActivationCA3.Visible = false;
                lblMsgActivationCA4.Visible = false;
                lblMsgActivationCA5.Visible = false;

            }

           // Liste des actualisations :
                popDgvAA();
                popDgvEV();
                popCbGestDep();
                popDgvGestDep();
                popCbGestRec();
                popDgvGestRec();
                popDgv5derniereRecoltes();
                popDgv5derniereDepenses();
                popTbTotalDep();
                popTbTotalRecettes();

        }
        private void Main_Shown(object sender, EventArgs e)
        {
            tbAjouAA.Focus();
        }       

        private void pnlAjoutAA_VisibleChanged(object sender, EventArgs e)
        {
            tbAjouAA.Focus();
        }
        private void btnResetAA_Click(object sender, EventArgs e)
        {
            tbAjouAA.Text = "";
            lblMsgAjouAA.Text = "";
            tbAjouAA.Focus();
        }
        private void btnAjouAA_Click(object sender, EventArgs e)
        {
            // variables locales : 
            bool trouver = false;
            string nTable = "activite_agricole", nLib = "libActAgri", nStatut = "statutActAgri", input = tbAjouAA.Text.Trim();

            if (tbAjouAA.Text == "")
            {
                lblMsgAjouAA.Text = "Veillez Saisir Une Activité Agricole.";    
            }else if(tbAjouAA.Text.Length >=25){
                lblMsgAjouAA.Text = "Trop Long. Max 25 Caractères.";
            }
            else
            {
               

                if (jeVeuxModifier.numElement == 0)
                {
                    // verification de doublons :
                    trouver = duplicatedStringFound(nTable, nLib, nStatut, input,"statutArchActAgri");

                    if (trouver)
                    {
                        MessageBox.Show("L'élément existe déjà.");
                        tbAjouAA.Text = "";
                        tbAjouAA.Focus();
                    }
                    else
                    {
                        // reformatage de la donnee : 
                        string text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(tbAjouAA.Text.ToLower());
                        // insertion dans la base de donnees :
                        try
                        {
                            conn = new MySqlConnection(cs);
                            conn.Open();

                            MySqlCommand cmd = new MySqlCommand();
                            cmd.Connection = conn;
                            cmd.CommandText = "insert into activite_agricole(libActAgri, numGerant) values(@a, @b)";
                            cmd.Prepare();

                            cmd.Parameters.AddWithValue("@a", text);
                            cmd.Parameters.AddWithValue("@b", LogInfo.UserID);
                            cmd.ExecuteNonQuery();

                            tbAjouAA.Text = "";

                            MessageBox.Show(" L'actvité agricole a été bien enrégistrée.");

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            if (conn != null)
                            {
                                conn.Close();
                            }
                        }
                    }
                }
                else
                {
                    
                    // verif si valeur tb existe active dans la db : 
                    trouver = duplicatedStringFound(nTable, nLib, nStatut, input,"statutArchActAgri");
                    if (trouver)
                    {
                        // message doublon et effaçaage et reinitailisation :
                        MessageBox.Show(" L'élément existe déjà.");
                        jeVeuxModifier.numElement = 0;                        
                        tbAjouAA.Text = "";
                        tbAjouAA.Focus();
                        btnAjouAA.Text = "Ajouter";
                    }
                    else
                    {
                        string a = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(tbAjouAA.Text.ToLower());
                        // on fait la maj et on reinitialise l'élément :
                        try
                        {

                            conn = new MySqlConnection(cs);
                            conn.Open();

                            MySqlCommand cmd = new MySqlCommand();
                            cmd.Connection = conn;
                            cmd.CommandText = "update activite_agricole set libActAgri = @a  where numActAgri = @b";
                            cmd.Prepare();

                            cmd.Parameters.AddWithValue("@a",a);
                            cmd.Parameters.AddWithValue("@b", jeVeuxModifier.numElement);
                            cmd.ExecuteNonQuery();

                            jeVeuxModifier.numElement = 0;
                            tbAjouAA.Text = "";
                            MessageBox.Show(" L'élément a été correctement Modifié.");

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {

                            if (conn != null)
                            {
                                conn.Close();
                            }

                        }

                        btnAjouAA.Text = "Ajouter";
                    }

                   

                }
                
            }
        }
        private void dgvAA_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
           
            if (e.RowIndex != -1)
           {
               
                if (e.ColumnIndex == 2)
                {

                    if (MessageBox.Show(" Voulez-vous vraiment Modifier cet élément? ", "Confirmation De Modification", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        // initialisation de j :
                        jeVeuxModifier.numElement = Convert.ToInt32(dgvAA.Rows[e.RowIndex].Cells["numActAgri"].Value.ToString());
                        tbAjouAA.Focus();
                        tbAjouAA.Text = dgvAA.Rows[e.RowIndex].Cells["libActAgri"].Value.ToString();
                        btnAjouAA.Text = "Modifier";

                    }

                }
                else if (e.ColumnIndex == 3)
                {
                    if (tbAjouAA.Text =="Modifier")
                    {
                        tbAjouAA.Text = "Ajouter";
                    }
                    // recupere l'id :
                    string numAA = dgvAA.Rows[e.RowIndex].Cells["numActAgri"].Value.ToString();

                    if (MessageBox.Show(" Voulez-vous vraiment supprimer cet élément? ", "Confirmation De Suppression", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        // on peut supprimer :
                        try
                        {

                            conn = new MySqlConnection(cs);
                            conn.Open();

                            MySqlCommand cmd = new MySqlCommand();
                            cmd.Connection = conn;
                            cmd.CommandText = "update activite_agricole set statutActAgri = 0  where numActAgri = @a";
                            cmd.Prepare();

                            cmd.Parameters.AddWithValue("@a", Convert.ToInt32(numAA));
                            cmd.ExecuteNonQuery();

                            MessageBox.Show(" L'élément a été correctement supprimé.");

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {

                            if (conn != null)
                            {
                                conn.Close();
                            }

                        }

                    }

                }


            }

        }
        private void btnResetEV_Click(object sender, EventArgs e)
        {
            lblMsgAjouEV.Text = "";
            tbAjouPrixEV.Text = "";
            tbAjouLibEV.Text = "";
            btnAjouEV.Text = "Ajouter";
            tbAjouLibEV.Focus();


        }
     

        private void pnlAjouEV_VisibleChanged(object sender, EventArgs e)
        {
            tbAjouLibEV.Focus();
        }
        private void btnAjouEV_Click(object sender, EventArgs e)
        {
            /*
             * # reformatage es variables :
             * a => "Entrer une activité agricole"
             * b => "Entrer le prix au Kg correspondant"
             * c => tblibEspVeg
             * d =W tbpuEspVeg
            */
           
            string a = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(tbAjouLibEV.Text.Trim().ToLower());
            string b = tbAjouPrixEV.Text.Trim();

            if (a =="" || b == "")
            {
                lblMsgAjouEV.Text = "Veillez remplir les champs SVP.";
            }
            else if (a.Length > 25)
            {
                lblMsgAjouEV.Text = "Nom trop long. Max 25 caractères.";
            }
            else
            {
                // test du regex sur le prix :
                bool estReel = Regex.IsMatch(b, @"^\s*([0-9])+\s*$");
                if (estReel== false)
                {
                    lblMsgAjouEV.Text = "    Le Prix doit être un entier.";
                }
                else
                {
                    if (jeVeuxModifier.numElement == 0)
                    {
                        // verification si la donnée entrée existe, est active et non archvée : 
                        try
                        {
                            conn = new MySqlConnection(cs);
                            conn.Open();

                            MySqlCommand cmd = new MySqlCommand();
                            cmd.Connection = conn;
                            cmd.CommandText = "SELECT COUNT(*) from espece_vegetale where libEspVeg = @a and statutEspVeg = 1 and statutArchEspVeg = 0";
                            cmd.Prepare();
                            cmd.Parameters.AddWithValue("@a",a);
                            int valeurCount = Convert.ToInt32(cmd.ExecuteScalar());

                            if (valeurCount > 0)
                            {
                                // message élément enrégistrée
                                MessageBox.Show("Une espèce est déja enrégistrée avec ces informations.");
                                tbAjouLibEV.Text = "";
                                tbAjouPrixEV.Text = "";
                                btnAjouEV.Text = "Ajouter";
                                tbAjouLibEV.Focus();
                            }
                            else
                            {
                              // insertion de l'élément :
                                try
                                {
                                    conn = new MySqlConnection(cs);
                                    conn.Open();

                                    MySqlCommand cmd2 = new MySqlCommand();
                                    cmd2.Connection = conn;
                                    cmd2.CommandText = "insert into espece_vegetale(libEspVeg, puEspVeg, numGerant) values(@a, @b, @c)";
                                    cmd2.Prepare();

                                    cmd2.Parameters.AddWithValue("@a", a);
                                    cmd2.Parameters.AddWithValue("@b", b);
                                    cmd2.Parameters.AddWithValue("@c", LogInfo.UserID);
                                    cmd2.ExecuteNonQuery();

                                    tbAjouLibEV.Text = "";
                                    tbAjouPrixEV.Text = "";

                                    MessageBox.Show(" Cet élément a été bien enrégistrée.");

                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                                finally
                                {
                                    if (conn != null)
                                    {
                                        conn.Close();
                                    }
                                }

                            }

                        }
                        catch (MySqlException exp)
                        {
                            MessageBox.Show(exp.Message);
                        }
                        finally
                        {
                            if (conn != null)
                            {
                                conn.Close();
                            }
                        }
                                                

                    }
                    else
                    { 
                        // modification : 
                        try
                        {
                            conn = new MySqlConnection(cs);
                            conn.Open();
                            
                            MySqlCommand cmd = new MySqlCommand();
                            cmd.Connection = conn;
                            cmd.CommandText = "SELECT COUNT(*) from espece_vegetale where libEspVeg = @a and statutEspVeg = 1 and statutArchEspVeg = 0";
                            cmd.Prepare();
                            cmd.Parameters.AddWithValue("@a", a);
                            int valeurCount = Convert.ToInt32(cmd.ExecuteScalar());

                            if (valeurCount > 0)
                            {
                                // message élément enrégistrée
                                MessageBox.Show("Une espèce est déja enrégistrée avec ces informations.");
                                tbAjouLibEV.Text = "";
                                tbAjouPrixEV.Text = "";
                                btnAjouEV.Text = "Ajouter";
                                tbAjouLibEV.Focus();
                            }
                            else
                            {
                                // mis à jour de l'élément : 
                                conn = new MySqlConnection(cs);
                                conn.Open();

                                MySqlCommand cmd2 = new MySqlCommand();
                                cmd2.Connection = conn;
                                cmd2.CommandText = "update espece_vegetale set libEspVeg = @a, puEspVeg =@b  where numEspVeg = @c";
                                cmd2.Prepare();

                                cmd2.Parameters.AddWithValue("@a", a);
                                cmd2.Parameters.AddWithValue("@b", Convert.ToInt32(b));
                                cmd2.Parameters.AddWithValue("@c", jeVeuxModifier.numElement);
                                cmd2.ExecuteNonQuery();

                                jeVeuxModifier.numElement = 0;
                                btnAjouEV.Text = "Ajouter";
                                tbAjouLibEV.Text = "";
                                tbAjouPrixEV.Text = "";
                                MessageBox.Show(" L'élément a été correctement Modifié.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            
                        }
                        finally
                        {
                            if (conn != null)
                            {
                                conn.Close();
                            }
                        }
                    }
                   
                }

            }
        }
        private void tbAjouLibEV_Enter(object sender, EventArgs e)
        {
            lblMsgAjouEV.Text = "";
        }
        private void tbAjouPrixEV_Enter(object sender, EventArgs e)
        {
            lblMsgAjouEV.Text = "";
        }
        private void dgvEV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (e.ColumnIndex == 3)
                {

                    if (MessageBox.Show(" Voulez-vous vraiment Modifier cet élément? ", "Confirmation De Modification", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        // initialisation de j :
                        jeVeuxModifier.numElement = Convert.ToInt32(dgvEV.Rows[e.RowIndex].Cells["numEspVeg"].Value.ToString());
                        tbAjouLibEV.Focus();
                        tbAjouLibEV.Text = dgvEV.Rows[e.RowIndex].Cells["libEspVeg"].Value.ToString();
                        tbAjouPrixEV.Text = dgvEV.Rows[e.RowIndex].Cells["puEspVeg"].Value.ToString();
                        btnAjouEV.Text = "Modifier";
                    }

                }
                else if(e.ColumnIndex == 4)
                {
                    
                    // recupere l'id :
                    string numEV = dgvEV.Rows[e.RowIndex].Cells["numEspVeg"].Value.ToString();
                    
                    if (MessageBox.Show(" Voulez-vous vraiment supprimer cet élément? ", "Confirmation De Suppression", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        // on peut supprimer :
                        try
                        {

                            conn = new MySqlConnection(cs);
                            conn.Open();

                            MySqlCommand cmd = new MySqlCommand();
                            cmd.Connection = conn;
                            cmd.CommandText = "update espece_vegetale set statutEspVeg = 0  where numespVeg = @a";
                            cmd.Prepare();

                            cmd.Parameters.AddWithValue("@a", Convert.ToInt32(numEV));
                            cmd.ExecuteNonQuery();

                            MessageBox.Show(" L'élément a été correctement supprimé.");

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {

                            if (conn != null)
                            {
                                conn.Close();
                            }

                        }

                    }

                }
 
            }
        }

        private void pnlGestDep_VisibleChanged(object sender, EventArgs e)
        {
            cbActAgri.Focus();
        }
        private void btnAjouDep_Click(object sender, EventArgs e)
        {
            // reformatage des informations dans la base de données : 
            /*
             *  a => cb act agri
             *  b => tb mtantDep
             *  c => tb description dep
             */
            string a = cbActAgri.SelectedValue.ToString();
            string b = tbMontantDep.Text.Trim();
            string c = tbDespDep.Text.Trim();

            if ( a=="" || b =="" || c == "")
            {
                lblMsgGestDep.Text = "         Remplissez tous les champs SVP.";
            }
            else
            {
                // test du regex : 
                bool estReel = Regex.IsMatch(b, @"^\s*([0-9])+\s*$");
                if (estReel == false)
                {
                    lblMsgGestDep.Text = "Le montant de la dépense doit être un entier.";
                }
                else if(c.Length > 80)
                {
                    lblMsgGestDep.Text = "La description trop longue. Max 80 caractères.";
                }
                else
                {
                    if (jeVeuxModifier.numElement == 0)
                    {
                         // insertion :
                            try
                            {
                                // formatage de la date : 
                                DateTime today = DateTime.Now;
                                conn = new MySqlConnection(cs);
                                conn.Open();


                                MySqlCommand cmd = new MySqlCommand();
                                cmd.Connection = conn;
                                cmd.CommandText = "insert into depense(descDep,montantDep, dateEnregDep, numGerant, numActAgri, numCA) values(@a, @b, @c, @d, @e, @f)";
                                cmd.Prepare();

                                cmd.Parameters.AddWithValue("@a", c);
                                cmd.Parameters.AddWithValue("@b", b);
                                cmd.Parameters.AddWithValue("@c",today);
                                cmd.Parameters.AddWithValue("@d", LogInfo.UserID);
                                cmd.Parameters.AddWithValue("@e", a);
                                cmd.Parameters.AddWithValue("@f", LogInfo.caID);
                                cmd.ExecuteNonQuery();

                                cbActAgri.Text = "";
                                tbMontantDep.Text = "";
                                tbDespDep.Text = "";
                                MessageBox.Show(" La dépense a été bien enrégistrée.");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            finally
                            {
                                if (conn != null)
                                {
                                    conn.Close();
                                }
                            }
                        
                    }else
                    {
                        // modification :
                        try
                        {

                            conn = new MySqlConnection(cs);
                            conn.Open();

                            MySqlCommand cmd = new MySqlCommand();
                            cmd.Connection = conn;
                            cmd.CommandText = "update depense set descDep = @a, montantDep =@b, numActAgri = @c where numDep = @d";
                            cmd.Prepare();

                            cmd.Parameters.AddWithValue("@a", c);
                            cmd.Parameters.AddWithValue("@b", b);
                            cmd.Parameters.AddWithValue("@c", Convert.ToInt32(a));
                            cmd.Parameters.AddWithValue("@d", jeVeuxModifier.numElement);
                            cmd.ExecuteNonQuery();

                            jeVeuxModifier.numElement = 0;

                            btnAjouDep.Text = "Ajouter";
                            tbMontantDep.Text = "";
                            tbDespDep.Text = "";
                            MessageBox.Show(" La dépense a été correctement Modifié.");
                           
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {

                            if (conn != null)
                            {
                                conn.Close();
                            }

                        }


                    }
                }
                
            }
        }
        private void cbActAgri_Enter(object sender, EventArgs e)
        {
            lblMsgGestDep.Text = "";
        }
        private void tbMontantDep_Enter(object sender, EventArgs e)
        {
            lblMsgGestDep.Text = "";
        }
        private void tbDespDep_Enter(object sender, EventArgs e)
        {
            lblMsgGestDep.Text = "";
        }
        private void btnResetDep_Click(object sender, EventArgs e)
        {
            cbActAgri.Text = "";
            tbMontantDep.Text = "";
            tbDespDep.Text = "";
            lblMsgGestDep.Text = "";
            btnAjouDep.Text = "Ajouter";
        }
        private void dgvGestDep_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (e.ColumnIndex == 6)
                {

                    if (MessageBox.Show(" Voulez-vous vraiment Modifier cet élément? ", "Confirmation De Modification", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        // initialisation de j :
                        jeVeuxModifier.numElement = Convert.ToInt32(dgvGestDep.Rows[e.RowIndex].Cells["a"].Value.ToString());
                        cbActAgri.SelectedValue = Convert.ToInt32(dgvGestDep.Rows[e.RowIndex].Cells["b"].Value.ToString());
                        tbMontantDep.Text = dgvGestDep.Rows[e.RowIndex].Cells["f"].Value.ToString();
                        tbDespDep.Text = dgvGestDep.Rows[e.RowIndex].Cells["e"].Value.ToString();
                        btnAjouDep.Text = "Modifier";  
                    }

                }
                else if (e.ColumnIndex == 7)
                {

                    // recupere l'id :
                    string numDep = dgvGestDep.Rows[e.RowIndex].Cells["a"].Value.ToString();

                    if (MessageBox.Show(" Voulez-vous vraiment supprimer cet élément? ", "Confirmation De Suppression", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        // on peut supprimer :
                        try
                        {

                            conn = new MySqlConnection(cs);
                            conn.Open();

                            MySqlCommand cmd = new MySqlCommand();
                            cmd.Connection = conn;
                            cmd.CommandText = "update depense set statutDep = 0  where numDep = @a";
                            cmd.Prepare();

                            cmd.Parameters.AddWithValue("@a", Convert.ToInt32(numDep));
                            cmd.ExecuteNonQuery();

                            MessageBox.Show(" Cette Dépense a été correctement supprimé.");

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {

                            if (conn != null)
                            {
                                conn.Close();
                            }

                        }

                    }

                }

            }

        }

        private void btnAjouRec_Click(object sender, EventArgs e)
        {
            // reformatage des informations dans la base de données : 
            /*
             *  a => cb esp veg
             *  b => tb qtte rec
             */
            string a = cbEspVeg.SelectedValue.ToString();
            string b = tbQtteRec.Text.Trim();

            if (a == "" || b == "")
            {
                lblMsgAjouRec.Text = " Veillez remplir tous les champs SVP.";
            }
            else
            {
                // test du regex : 
                bool estReel = Regex.IsMatch(b, @"^\s*([0-9])+\s*$");
                if (estReel == false)
                {
                    lblMsgAjouRec.Text = "La quantité récoltée doit être un entier.";
                }
                else
                {
                    if (jeVeuxModifier.numElement == 0)
                    {
                        // insertion :
                        try
                        {
                            // formatage de la date : 
                            DateTime today = DateTime.Now;
                            conn = new MySqlConnection(cs);
                            conn.Open();


                            MySqlCommand cmd = new MySqlCommand();
                            cmd.Connection = conn;
                            cmd.CommandText = "insert into produire(dateRecolte, qtteRecolte, numCa, numEspVeg) values(@a, @b, @c, @d)";
                            cmd.Prepare();

                            cmd.Parameters.AddWithValue("@a", today);
                            cmd.Parameters.AddWithValue("@b", b);
                            cmd.Parameters.AddWithValue("@c", LogInfo.caID);
                            cmd.Parameters.AddWithValue("@d", a);
                            cmd.ExecuteNonQuery();

                            cbEspVeg.Text = "";
                            tbQtteRec.Text = "";
                        
                            MessageBox.Show(" La récolte a été bien enrégistrée.");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            if (conn != null)
                            {
                                conn.Close();
                            }
                        }
                    }
                    else
                    {                      
                       // modification :
                        try
                        {

                            conn = new MySqlConnection(cs);
                            conn.Open();

                            MySqlCommand cmd = new MySqlCommand();
                            cmd.Connection = conn;
                            cmd.CommandText = "update produire set qtteRecolte = @a, numEspVeg =@b where dateRecolte = @c";
                            cmd.Prepare();

                            cmd.Parameters.AddWithValue("@a",b);
                            cmd.Parameters.AddWithValue("@b", a);
                            cmd.Parameters.AddWithValue("@c", Convert.ToDateTime(jeVeuxModifier.uneDate));
                            cmd.ExecuteNonQuery();

                            jeVeuxModifier.numElement = 0;
                            jeVeuxModifier.uneDate = "";

                            btnAjouRec.Text = "Ajouter";
                            tbQtteRec.Text = "";
                            cbEspVeg.Text = "";
                            MessageBox.Show(" La dépense a été correctement Modifié.");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {

                            if (conn != null)
                            {
                                conn.Close();
                            }

                        }

                    }
                }
            }
        }
        private void dgvGestRec_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (e.ColumnIndex == 4)
                {

                    if (MessageBox.Show(" Voulez-vous vraiment Modifier cet élément? ", "Confirmation De Modification", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        // initialisation de j :
                        jeVeuxModifier.numElement = 1;
                        jeVeuxModifier.uneDate = dgvGestRec.Rows[e.RowIndex].Cells["dateRec"].Value.ToString();
                        cbEspVeg.SelectedValue = Convert.ToInt32(dgvGestRec.Rows[e.RowIndex].Cells["numEspVegetale"].Value.ToString());
                        tbQtteRec.Text = dgvGestRec.Rows[e.RowIndex].Cells["qtteRecolte"].Value.ToString();
                        btnAjouRec.Text = "Modifier";
                    }

                }
                else if (e.ColumnIndex == 5)
                {

                    // recupere l'id :
                    string dateRec = dgvGestRec.Rows[e.RowIndex].Cells["dateRec"].Value.ToString();
                    if (MessageBox.Show(" Voulez-vous vraiment supprimer cet élément? ", "Confirmation De Suppression", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        // on peut supprimer :
                        try
                        {
                            conn = new MySqlConnection(cs);
                            conn.Open();
                            MySqlCommand cmd = new MySqlCommand();
                            cmd.Connection = conn;
                            cmd.CommandText = "update produire set statutRec = 0  where dateRecolte = @a";
                            cmd.Prepare();
                            cmd.Parameters.AddWithValue("@a", Convert.ToDateTime(dateRec));
                            cmd.ExecuteNonQuery();
                            MessageBox.Show(" Cette récolte a été correctement supprimé.");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {

                            if (conn != null)
                            {
                                conn.Close();
                            }

                        }

                    }

                }

            }

        }
        private void btnResetRec_Click(object sender, EventArgs e)
        {
            lblMsgAjouRec.Text = "";
            tbQtteRec.Text = "";

        }
        private void tbQtteRec_Enter(object sender, EventArgs e)
        {
            lblMsgAjouRec.Text = "";
        }

        private void btnPrintDepCa_Click(object sender, EventArgs e)
        {
            // on efface la dgv : 
            dgvReportDep.Rows.Clear();


            // on fait la selection dans la base : 
            try
            {
                conn = new MySqlConnection(cs);
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select depense.dateEnregDep as a, activite_agricole.libActAgri as b, depense.descDep as c, depense.montantDep as d from depense INNER JOIN activite_agricole ON depense.numActAgri = activite_agricole.numActAgri where depense.numCA = @a AND depense.statutDep = 1 and depense.statutArchDep = 0 order by depense.numDep desc";
                cmd.Parameters.AddWithValue("@a", LogInfo.caID);

                rdr = cmd.ExecuteReader();
                int i = 1;
                // population of the dgv:
                while (rdr.Read())
                {
                    string a = rdr.GetDateTime(0).ToString();
                    string b = rdr.GetString(1);
                    string c = rdr.GetString(2);
                    string d = rdr.GetInt32(3).ToString();
                    dgvReportDep.Rows.Add(
                        new object[] {i,a, b, c, d});
                    i++;
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

        // configuration du boutton d'impression : 
            //Open the print dialog
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = pdReportDep; // modif
            printDialog.UseEXDialog = true;

            //Get the document
            if (DialogResult.OK == printDialog.ShowDialog())
            {
                // formatage de la date : 
                String tmp = DateTime.Now.ToString();

                pdReportDep.DocumentName = "Etat_depenses_"+tmp; // modif
                pdReportDep.Print(); // modif
            }

            //Open the print preview dialog
            //PrintPreviewDialog objPPdialog = new PrintPreviewDialog();
            //objPPdialog.Document = printDocument1;
            //objPPdialog.ShowDialog();    
        }

        private void pdReportDep_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                strFormat = new StringFormat();
                strFormat.Alignment = StringAlignment.Near;
                strFormat.LineAlignment = StringAlignment.Center;
                strFormat.Trimming = StringTrimming.EllipsisCharacter;

                arrColumnLefts.Clear();
                arrColumnWidths.Clear();
                iCellHeight = 0;
                iRow = 0;
                bFirstPage = true;
                bNewPage = true;

                // Calculating Total Widths
                iTotalWidth = 0;
                foreach (DataGridViewColumn dgvGridCol in dgvReportDep.Columns)
                {
                    iTotalWidth += dgvGridCol.Width - 22;// modif
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void pdReportDep_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                //Set the left margin
                int iLeftMargin = 15; // modif
                //Set the top margin
                int iTopMargin = e.MarginBounds.Top;
                //Whether more pages have to print or not
                bool bMorePagesToPrint = false;
                int iTmpWidth = 0;

                //For the first page to print set the cell width and header height
                if (bFirstPage)
                {
                    foreach (DataGridViewColumn GridCol in dgvReportDep.Columns)
                    {
                        iTmpWidth = (int)(Math.Floor((double)((double)GridCol.Width /
                                       (double)iTotalWidth * (double)iTotalWidth *
                                       ((double)e.MarginBounds.Width / (double)iTotalWidth))));

                        iHeaderHeight = (int)(e.Graphics.MeasureString(GridCol.HeaderText,
                                    GridCol.InheritedStyle.Font, iTmpWidth).Height) + 11;

                        // Save width and height of headres
                        arrColumnLefts.Add(iLeftMargin);
                        arrColumnWidths.Add(iTmpWidth);
                        iLeftMargin += iTmpWidth;
                    }
                }
                //Loop till all the grid rows not get printed
                while (iRow <= dgvReportDep.Rows.Count - 1)
                {
                    DataGridViewRow GridRow = dgvReportDep.Rows[iRow];
                    //Set the cell height
                    iCellHeight = GridRow.Height + 15;// modif 10
                    int iCount = 0;
                    //Check whether the current page settings allo more rows to print
                    if (iTopMargin + iCellHeight >= e.MarginBounds.Height + e.MarginBounds.Top)
                    {
                        bNewPage = true;
                        bFirstPage = false;
                        bMorePagesToPrint = true;
                        break;
                    }
                    else
                    {
                        if (bNewPage)
                        {
                            //Draw Header
                            e.Graphics.DrawString("Etat Des Dépenses", new Font(dgvReportDep.Font, FontStyle.Bold),
                                    Brushes.Black, e.MarginBounds.Left, e.MarginBounds.Top -
                                    e.Graphics.MeasureString("Etat Des Dépenses ", new Font(dgvReportDep.Font,
                                    FontStyle.Bold), e.MarginBounds.Width).Height - 13);

                            String strDate = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString();
                            //Draw Date
                            e.Graphics.DrawString(strDate, new Font(dgvReportDep.Font, FontStyle.Bold),
                                    Brushes.Black, e.MarginBounds.Left + (e.MarginBounds.Width -
                                    e.Graphics.MeasureString(strDate, new Font(dgvReportDep.Font,
                                    FontStyle.Bold), e.MarginBounds.Width).Width), e.MarginBounds.Top -
                                    e.Graphics.MeasureString("Etat Des Dépenses", new Font(new Font(dgvReportDep.Font,
                                    FontStyle.Bold), FontStyle.Bold), e.MarginBounds.Width).Height - 13);

                            //Draw Columns                 
                            iTopMargin = e.MarginBounds.Top;
                            foreach (DataGridViewColumn GridCol in dgvReportDep.Columns)
                            {
                                e.Graphics.FillRectangle(new SolidBrush(Color.LightGray),
                                    new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight));

                                e.Graphics.DrawRectangle(Pens.Black,
                                    new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight));

                                e.Graphics.DrawString(GridCol.HeaderText, GridCol.InheritedStyle.Font,
                                    new SolidBrush(GridCol.InheritedStyle.ForeColor),
                                    new RectangleF((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight), strFormat);
                                iCount++;
                            }
                            bNewPage = false;
                            iTopMargin += iHeaderHeight;
                        }
                        iCount = 0;
                        //Draw Columns Contents                
                        foreach (DataGridViewCell Cel in GridRow.Cells)
                        {
                            if (Cel.Value != null)
                            {
                                e.Graphics.DrawString(Cel.Value.ToString(), Cel.InheritedStyle.Font,
                                            new SolidBrush(Cel.InheritedStyle.ForeColor),
                                            new RectangleF((int)arrColumnLefts[iCount], (float)iTopMargin,
                                            (int)arrColumnWidths[iCount], (float)iCellHeight), strFormat);
                            }
                            //Drawing Cells Borders 
                            e.Graphics.DrawRectangle(Pens.Black, new Rectangle((int)arrColumnLefts[iCount],
                                    iTopMargin, (int)arrColumnWidths[iCount], iCellHeight));

                            iCount++;
                        }
                    }
                    iRow++;
                    iTopMargin += iCellHeight;
                }

                //If more lines exist, print another page.
                if (bMorePagesToPrint)
                    e.HasMorePages = true;
                else
                    e.HasMorePages = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        #region debut des traiments pour le report des recoltes
        private void btnPrintRec_Click(object sender, EventArgs e)
        {
            // on efface la dgv : 
            dgvReportRec.Rows.Clear();


            // on fait la selection dans la base : 
            try
            {
                conn = new MySqlConnection(cs);
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select produire.dateRecolte as a, espece_vegetale.libEspVeg as b, produire.qtteRecolte as c from produire INNER join espece_vegetale ON produire.numEspVeg = espece_vegetale.numEspVeg where produire.statutRec = 1 and produire.statutArchRec = 0  and produire.numCA = @a order by produire.dateRecolte desc";
                cmd.Parameters.AddWithValue("@a", LogInfo.caID);

                rdr = cmd.ExecuteReader();
                int i = 1;
                // population of the dgv:
                while (rdr.Read())
                {
                    string a = rdr.GetDateTime(0).ToString();
                    string b = rdr.GetString(1);
                    string c = rdr.GetInt32(2).ToString();
                    dgvReportRec.Rows.Add(
                        new object[] { i, a, b, c });
                    i++;
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

            // configuration du boutton d'impression : 
            //Open the print dialog
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = pdReportRec; // modif
            printDialog.UseEXDialog = true;

            //Get the document
            if (DialogResult.OK == printDialog.ShowDialog())
            {
                // formatage de la date : 
                String tmp = DateTime.Now.ToString();

                pdReportRec.DocumentName = "Etat_recoltes_"+tmp;// modif
                pdReportRec.Print(); // modif
            }

            //Open the print preview dialog
            //PrintPreviewDialog objPPdialog = new PrintPreviewDialog();
            //objPPdialog.Document = printDocument1;
            //objPPdialog.ShowDialog();
            

        }

        private void pdReportRec_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                strFormat = new StringFormat();
                strFormat.Alignment = StringAlignment.Near;
                strFormat.LineAlignment = StringAlignment.Center;
                strFormat.Trimming = StringTrimming.EllipsisCharacter;

                arrColumnLefts.Clear();
                arrColumnWidths.Clear();
                iCellHeight = 0;
                iRow = 0;
                bFirstPage = true;
                bNewPage = true;

                // Calculating Total Widths
                iTotalWidth = 0;
                foreach (DataGridViewColumn dgvGridCol in dgvReportRec.Columns)
                {
                    iTotalWidth += dgvGridCol.Width - 22;// modif
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void pdReportRec_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                //Set the left margin
                int iLeftMargin = 15; // modif
                //Set the top margin
                int iTopMargin = e.MarginBounds.Top;
                //Whether more pages have to print or not
                bool bMorePagesToPrint = false;
                int iTmpWidth = 0;

                //For the first page to print set the cell width and header height
                if (bFirstPage)
                {
                    foreach (DataGridViewColumn GridCol in dgvReportRec.Columns)
                    {
                        iTmpWidth = (int)(Math.Floor((double)((double)GridCol.Width /
                                       (double)iTotalWidth * (double)iTotalWidth *
                                       ((double)e.MarginBounds.Width / (double)iTotalWidth))));

                        iHeaderHeight = (int)(e.Graphics.MeasureString(GridCol.HeaderText,
                                    GridCol.InheritedStyle.Font, iTmpWidth).Height) + 11;

                        // Save width and height of headres
                        arrColumnLefts.Add(iLeftMargin);
                        arrColumnWidths.Add(iTmpWidth);
                        iLeftMargin += iTmpWidth;
                    }
                }
                //Loop till all the grid rows not get printed
                while (iRow <= dgvReportRec.Rows.Count - 1)
                {
                    DataGridViewRow GridRow = dgvReportRec.Rows[iRow];
                    //Set the cell height
                    iCellHeight = GridRow.Height + 15;// modif 10
                    int iCount = 0;
                    //Check whether the current page settings allo more rows to print
                    if (iTopMargin + iCellHeight >= e.MarginBounds.Height + e.MarginBounds.Top)
                    {
                        bNewPage = true;
                        bFirstPage = false;
                        bMorePagesToPrint = true;
                        break;
                    }
                    else
                    {
                        if (bNewPage)
                        {
                            //Draw Header
                            e.Graphics.DrawString("Etat Des Récoltes", new Font(dgvReportRec.Font, FontStyle.Bold),
                                    Brushes.Black, e.MarginBounds.Left, e.MarginBounds.Top -
                                    e.Graphics.MeasureString("Etat Des Récoltes ", new Font(dgvReportRec.Font,
                                    FontStyle.Bold), e.MarginBounds.Width).Height - 13);

                            String strDate = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString();
                            //Draw Date
                            e.Graphics.DrawString(strDate, new Font(dgvReportRec.Font, FontStyle.Bold),
                                    Brushes.Black, e.MarginBounds.Left + (e.MarginBounds.Width -
                                    e.Graphics.MeasureString(strDate, new Font(dgvReportRec.Font,
                                    FontStyle.Bold), e.MarginBounds.Width).Width), e.MarginBounds.Top -
                                    e.Graphics.MeasureString("Etat Des Récoltes", new Font(new Font(dgvReportRec.Font,
                                    FontStyle.Bold), FontStyle.Bold), e.MarginBounds.Width).Height - 13);

                            //Draw Columns                 
                            iTopMargin = e.MarginBounds.Top;
                            foreach (DataGridViewColumn GridCol in dgvReportRec.Columns)
                            {
                                e.Graphics.FillRectangle(new SolidBrush(Color.LightGray),
                                    new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight));

                                e.Graphics.DrawRectangle(Pens.Black,
                                    new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight));

                                e.Graphics.DrawString(GridCol.HeaderText, GridCol.InheritedStyle.Font,
                                    new SolidBrush(GridCol.InheritedStyle.ForeColor),
                                    new RectangleF((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight), strFormat);
                                iCount++;
                            }
                            bNewPage = false;
                            iTopMargin += iHeaderHeight;
                        }
                        iCount = 0;
                        //Draw Columns Contents                
                        foreach (DataGridViewCell Cel in GridRow.Cells)
                        {
                            if (Cel.Value != null)
                            {
                                e.Graphics.DrawString(Cel.Value.ToString(), Cel.InheritedStyle.Font,
                                            new SolidBrush(Cel.InheritedStyle.ForeColor),
                                            new RectangleF((int)arrColumnLefts[iCount], (float)iTopMargin,
                                            (int)arrColumnWidths[iCount], (float)iCellHeight), strFormat);
                            }
                            //Drawing Cells Borders 
                            e.Graphics.DrawRectangle(Pens.Black, new Rectangle((int)arrColumnLefts[iCount],
                                    iTopMargin, (int)arrColumnWidths[iCount], iCellHeight));

                            iCount++;
                        }
                    }
                    iRow++;
                    iTopMargin += iCellHeight;
                }

                //If more lines exist, print another page.
                if (bMorePagesToPrint)
                    e.HasMorePages = true;
                else
                    e.HasMorePages = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        #endregion fin des traiments pour le report des recoltes
    }
}
