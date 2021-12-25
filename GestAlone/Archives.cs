using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace GestAlone
{
    public partial class Archives : Form
    {
        string cs = @"server=localhost;userid=root;password=;database=gestalonebis";
        MySqlConnection conn = null;
        MySqlDataReader rdr = null;

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


        // les methodes 
        public void popDgvArchivesDep()
        {
            dgvArchivesDep.Rows.Clear();
            try
            {
                conn = new MySqlConnection(cs);
                conn.Open();

                string stm = "select campagne_agricole.codeCA as a, depense.dateEnregDep as b, activite_agricole.libActAgri as c,depense.descDep as d, depense.montantDep as e from depense INNER join campagne_agricole on depense.numCA = campagne_agricole.numCA INNER JOIN activite_agricole ON depense.numActAgri = activite_agricole.numActAgri where depense.statutDep = 1 and depense.statutArchDep = 1 order by depense.dateEnregDep desc";
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    string a = rdr.GetString(0);
                    string b = rdr.GetDateTime(1).ToString();
                    string c = rdr.GetString(2);
                    string d = rdr.GetString(3);
                    string e = rdr.GetInt32(4).ToString();

                    dgvArchivesDep.Rows.Add(
                        new object[] 
                            { 
                               a,b,c,d,e
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
        public void popDgvArchivesRec()
        {
            dgvArchivesRec.Rows.Clear();

            // population de la dgv : 
            try
            {
                conn = new MySqlConnection(cs);
                conn.Open();

                string stm = "SELECT espece_vegetale.libEspVeg as a, produire.qtteRecolte as b, produire.dateRecolte as c, campagne_agricole.codeCa as d from produire INNER JOIN espece_vegetale ON produire.numEspVeg = espece_vegetale.numEspVeg INNER JOIN campagne_agricole ON produire.numCA = campagne_agricole.numCA where produire.statutRec = 1 and produire.statutArchRec = 1 order by produire.dateRecolte desc";
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    string a = rdr.GetString(0);
                    string b = rdr.GetInt32(1).ToString();
                    string c = rdr.GetDateTime(2).ToString();
                    string d = rdr.GetString(3);

                    dgvArchivesRec.Rows.Add(
                        new object[] 
                            { 
                               d,a,b,c
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
        public void poopCbCa()
        {
            // requete se selection ca : 
            try
            {
                conn = new MySqlConnection(cs);
                conn.Open();

                string stm = "SELECT numCa, codeCA FROM campagne_agricole where statutArchCA = 1 order by numca desc";
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                rdr = cmd.ExecuteReader();
                List<ca> list = new List<ca>();

                while (rdr.Read())
                {
                    list.Add(new ca() { numCA = rdr.GetInt32(0), codeCA = "Campagne Agricole N° " + rdr.GetString(1) });
                }
                cbCA.DataSource = list;
                cbCA.ValueMember = "numCA";
                cbCA.DisplayMember = "codeCA";
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
        public Archives()
        {
            InitializeComponent();
        }

        private void pbCloseArchives_Click(object sender, EventArgs e)
        {
            Main unMain = new Main();
            this.Close();          
            unMain.Show();
        }

        private void Archives_Activated(object sender, EventArgs e)
        {
            
        }

        private void Archives_Load(object sender, EventArgs e)
        {
            popDgvArchivesDep();
            popDgvArchivesRec();
            poopCbCa();

        }

        private void btnFiltrer_Click(object sender, EventArgs e)
        {
            dgvArchivesDep.Rows.Clear();
            dgvArchivesRec.Rows.Clear();

            String cbValue = cbCA.SelectedValue.ToString();
            
            // population de la dgv1 : 
                try{
            		conn = new MySqlConnection(cs);
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT espece_vegetale.libEspVeg as a, produire.qtteRecolte as b, produire.dateRecolte as c, campagne_agricole.numCA as d from produire INNER JOIN espece_vegetale ON produire.numEspVeg = espece_vegetale.numEspVeg INNER JOIN campagne_agricole ON produire.numCA = campagne_agricole.numCA where produire.statutRec = 1 and produire.statutArchRec = 1 and produire.numCA = @a  order by produire.dateRecolte desc";
                    cmd.Parameters.AddWithValue("@a", cbValue);
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        string a = rdr.GetString(0);
                        string b = rdr.GetInt32(1).ToString();
                        string c = rdr.GetDateTime(2).ToString();
                        string d = rdr.GetInt32(3).ToString();

                        dgvArchivesRec.Rows.Add(
                            new object[] 
                            { 
                               a,b,c,d
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

                try
                {
                    conn = new MySqlConnection(cs);
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "select campagne_agricole.codeCA as a, depense.dateEnregDep as b, activite_agricole.libActAgri as c,depense.descDep as d, depense.montantDep as e from depense INNER join campagne_agricole on depense.numCA = campagne_agricole.numCA INNER JOIN activite_agricole ON depense.numActAgri = activite_agricole.numActAgri where depense.statutDep = 1 and depense.statutArchDep = 1 and depense.numCA = @a order by depense.dateEnregDep desc";
                    cmd.Parameters.AddWithValue("@a", cbValue);
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        string a = rdr.GetString(0);
                        string b = rdr.GetDateTime(1).ToString();
                        string c = rdr.GetString(2);
                        string d = rdr.GetString(3);
                        string f = rdr.GetInt32(4).ToString();

                        dgvArchivesDep.Rows.Add(
                            new object[] 
                            { 
                               a,b,c,d,f
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

        

        private void btnPrintDep_Click(object sender, EventArgs e)
        {
            //Open the print dialog
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = pdDep;
            printDialog.UseEXDialog = true;

            //Get the document
            if (DialogResult.OK == printDialog.ShowDialog())
            {
                // formatage de la date : 
                String tmp = DateTime.Now.ToString();

                pdDep.DocumentName = "Etat_Depense_"+tmp;
                pdDep.Print();
            }

            //Open the print preview dialog
            //PrintPreviewDialog objPPdialog = new PrintPreviewDialog();
            //objPPdialog.Document = printDocument1;
            //objPPdialog.ShowDialog();
        }

        private void pdDep_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
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
                foreach (DataGridViewColumn dgvGridCol in dgvArchivesDep.Columns)
                {
                    iTotalWidth += dgvGridCol.Width - 30;// modif
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void pdDep_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
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
                    foreach (DataGridViewColumn GridCol in dgvArchivesDep.Columns)
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
                while (iRow <= dgvArchivesDep.Rows.Count - 1)
                {
                    DataGridViewRow GridRow = dgvArchivesDep.Rows[iRow];
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
                            e.Graphics.DrawString("Etat Des Dépenses", new Font(dgvArchivesDep.Font, FontStyle.Bold),
                                    Brushes.Black, e.MarginBounds.Left, e.MarginBounds.Top -
                                    e.Graphics.MeasureString("Etat Des Dépenses", new Font(dgvArchivesDep.Font,
                                    FontStyle.Bold), e.MarginBounds.Width).Height - 13);

                            String strDate = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString();
                            //Draw Date
                            e.Graphics.DrawString(strDate, new Font(dgvArchivesDep.Font, FontStyle.Bold),
                                    Brushes.Black, e.MarginBounds.Left + (e.MarginBounds.Width -
                                    e.Graphics.MeasureString(strDate, new Font(dgvArchivesDep.Font,
                                    FontStyle.Bold), e.MarginBounds.Width).Width), e.MarginBounds.Top -
                                    e.Graphics.MeasureString("Etat Des Dépenses", new Font(new Font(dgvArchivesDep.Font,
                                    FontStyle.Bold), FontStyle.Bold), e.MarginBounds.Width).Height - 13);

                            //Draw Columns                 
                            iTopMargin = e.MarginBounds.Top;
                            foreach (DataGridViewColumn GridCol in dgvArchivesDep.Columns)
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

        private void btnPrintRec_Click(object sender, EventArgs e)
        {
            //Open the print dialog
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = pdRec; // modif
            printDialog.UseEXDialog = true;

            //Get the document
            if (DialogResult.OK == printDialog.ShowDialog())
            {
                // formatage de la date : 
                String tmp = DateTime.Now.ToString();

                pdRec.DocumentName = "Etat_recoltes_"+tmp; // modif
                pdRec.Print(); // modif
            }

            //Open the print preview dialog
            //PrintPreviewDialog objPPdialog = new PrintPreviewDialog();
            //objPPdialog.Document = printDocument1;
            //objPPdialog.ShowDialog();

        }

        private void pdRec_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
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
                foreach (DataGridViewColumn dgvGridCol in dgvArchivesRec.Columns)
                {
                    iTotalWidth += dgvGridCol.Width - 30;// modif
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pdRec_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
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
                    foreach (DataGridViewColumn GridCol in dgvArchivesRec.Columns)
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
                while (iRow <= dgvArchivesRec.Rows.Count - 1)
                {
                    DataGridViewRow GridRow = dgvArchivesRec.Rows[iRow];
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
                            e.Graphics.DrawString("Etat Des Récoltes", new Font(dgvArchivesRec.Font, FontStyle.Bold),
                                    Brushes.Black, e.MarginBounds.Left, e.MarginBounds.Top -
                                    e.Graphics.MeasureString("Etat Des Récoltes ", new Font(dgvArchivesRec.Font,
                                    FontStyle.Bold), e.MarginBounds.Width).Height - 13);

                            String strDate = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString();
                            //Draw Date
                            e.Graphics.DrawString(strDate, new Font(dgvArchivesRec.Font, FontStyle.Bold),
                                    Brushes.Black, e.MarginBounds.Left + (e.MarginBounds.Width -
                                    e.Graphics.MeasureString(strDate, new Font(dgvArchivesRec.Font,
                                    FontStyle.Bold), e.MarginBounds.Width).Width), e.MarginBounds.Top -
                                    e.Graphics.MeasureString("Etat Des Récoltes", new Font(new Font(dgvArchivesRec.Font,
                                    FontStyle.Bold), FontStyle.Bold), e.MarginBounds.Width).Height - 13);

                            //Draw Columns                 
                            iTopMargin = e.MarginBounds.Top;
                            foreach (DataGridViewColumn GridCol in dgvArchivesRec.Columns)
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


        
    }
}
