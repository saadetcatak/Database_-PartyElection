using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Database__PartyElection
{
    public partial class FrmOyGiris : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source = SAADET\SQLEXPRESS01; Initial Catalog = DbElectionProject; Integrated Security = True");


        public FrmOyGiris()
        {
            InitializeComponent();
        }


        private void BtnOyGiris_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("Insert into TblDistrict(DistrictName,AParty,BParty,CParty,DParty,EParty) values(@p1,@p2,@p3,@p4,@p5,@p6)", connection);
            command.Parameters.AddWithValue("@p1", Txtİlce.Text);
            command.Parameters.AddWithValue("@p2", TxtA.Text);
            command.Parameters.AddWithValue("@p3", TxtB.Text);
            command.Parameters.AddWithValue("@p4", TxtC.Text);
            command.Parameters.AddWithValue("@p5", TxtD.Text);
            command.Parameters.AddWithValue("@p6", TxtE.Text);
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Oy Girişi gerçekleştirildi.");

        }

        private void BtnGrafikler_Click(object sender, EventArgs e)
        {
            FrmGrafikler frm=new FrmGrafikler();
            frm.Show();
        }
    }
}
