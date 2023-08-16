using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database__PartyElection
{
    public partial class FrmGrafikler : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source = SAADET\SQLEXPRESS01; Initial Catalog = DbElectionProject; Integrated Security = True");
        public FrmGrafikler()
        {
            InitializeComponent();
        }

        private void FrmGrafikler_Load(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("Select DistrictName from TblDistrict", connection);
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0]);
            }
            connection.Close();


            connection.Open();
            SqlCommand command1 = new SqlCommand("Select Sum(AParty), Sum(BParty), Sum(CParty), Sum(DParty), Sum(EParty) From TblDistrict", connection);
            SqlDataReader dr1 = command1.ExecuteReader();
            while (dr1.Read())
            {
                chart1.Series["Partiler"].Points.AddXY("A Parti", dr1[0]);
                chart1.Series["Partiler"].Points.AddXY("B Parti", dr1[1]);
                chart1.Series["Partiler"].Points.AddXY("C Parti", dr1[2]);
                chart1.Series["Partiler"].Points.AddXY("D Parti", dr1[3]);
                chart1.Series["Partiler"].Points.AddXY("E Parti", dr1[4]);
            }
            connection.Close();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command2 = new SqlCommand("Select*From TblDistrict where DistrictName=@p1",connection);
            command2.Parameters.AddWithValue("@p1", comboBox1.Text);
            SqlDataReader dr = command2.ExecuteReader();
            while (dr.Read()) 
            {
                progressBar1.Value =int.Parse(dr[2].ToString());
                progressBar2.Value =int.Parse(dr[3].ToString());
                progressBar3.Value =int.Parse(dr[4].ToString());
                progressBar4.Value =int.Parse(dr[5].ToString());
                progressBar5.Value =int.Parse(dr[6].ToString());

                LblA.Text= dr[2].ToString();
                LblB.Text= dr[3].ToString();
                LblC.Text= dr[4].ToString();
                LblD.Text= dr[5].ToString();
                LblE.Text= dr[6].ToString();
            }
            connection.Close() ;
        }
    }
}
