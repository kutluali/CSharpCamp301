using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpCamp301.EFProject
{
    public partial class FrmLocation : Form
    {
        public FrmLocation()
        {
            InitializeComponent();
        }

        CampEfTravelDbEntities db=new CampEfTravelDbEntities();
        private void btnList_Click(object sender, EventArgs e)
        {
            var values = db.Location.ToList();
            dataGridView1.DataSource = values;
        }

        private void FrmLocation_Load(object sender, EventArgs e)
        {
            var values = db.Guide.Select(x => new
            {
                FullName = x.Name + " " + x.Surname,
                x.GuideId
            }).ToList();

            cbGuide.DisplayMember = "FullName";
            cbGuide.ValueMember = "GuideId";
            cbGuide.DataSource = values;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Location location = new Location();
            location.Capacity=byte.Parse(nudCapacity.Value.ToString());
            location.City=txtCity.Text;
            location.Country=txtCountry.Text;
            location.DayNight=txtDays.Text;
            location.Price=decimal.Parse(txtPrice.Text);
            location.GuideId=int.Parse(cbGuide.SelectedValue.ToString());
            db.Location.Add(location);
            db.SaveChanges();
            MessageBox.Show("Ekleme İşlemi Başarılı");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var deleteValue = db.Location.Find(id);
            db.Location.Remove(deleteValue);
            db.SaveChanges();
            MessageBox.Show("Silme İşlemi Başarılı");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id=int.Parse(txtId.Text);
            var updateValue = db.Location.Find(id);
            updateValue.DayNight = txtDays.Text;
            updateValue.Capacity = byte.Parse(nudCapacity.Value.ToString());
            updateValue.City=txtCity.Text;
            updateValue.Country=txtCountry.Text;
            updateValue.GuideId = int.Parse(cbGuide.SelectedValue.ToString());
            updateValue.Price = decimal.Parse(txtPrice.Text);
            db.SaveChanges();
            MessageBox.Show("Başarılıu Bir Şekilde Güncellendi");
        }
    }
}
