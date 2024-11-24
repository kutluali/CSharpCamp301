using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpCamp301.EFProject
{
    public partial class FrmStatistics : Form
    {
        public FrmStatistics()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        CampEfTravelDbEntities db=new CampEfTravelDbEntities();
        private void FrmStatistics_Load(object sender, EventArgs e)
        {

            lblLocationCount.Text=db.Location.Count().ToString();
            lblSumCapacity.Text=db.Location.Sum(x=>x.Capacity).ToString();
            lblGuideCount.Text=db.Guide.Count().ToString();
            lblAvgCapacity.Text=db.Location.Average(x=>x.Capacity).ToString(); // Average = Ortalama
            lblAvgLocationPrice.Text=db.Location.Average(x=> x.Price).ToString() + "₺";

            int lastCountryId = db.Location.Max(x => x.LocationId);
            lblLastCountryName.Text = db.Location.Where(x => x.LocationId==lastCountryId).Select(y => y.Country).FirstOrDefault();

            lblCapadokyaLocationCapacity.Text = db.Location.Where(x => x.City == "Kapadokya").Select(y => y.Capacity).FirstOrDefault().ToString();

            lblTurkiyeAvgCapacity.Text=db.Location.Where(x=>x.Country =="Türkiye").Average(y=>y.Capacity).ToString();

            var RomeguideId=db.Location.Where(x=>x.City=="Roma Turistik").Select(y=>y.GuideId).FirstOrDefault();
            lblRomeGuideName.Text=db.Guide.Where(x=>x.GuideId==RomeguideId).Select(y=>y.Name + " " + y.Surname).FirstOrDefault().ToString();

            var maxCapacity=db.Location.Max(x=>x.Capacity);
            lblMaxCapacityLocation.Text=db.Location.Where(x=>x.Capacity==maxCapacity).Select(y=>y.City).FirstOrDefault().ToString();

            var maxPrice = db.Location.Max(x => x.Price);
            lblMaxPriceLocation.Text=db.Location.Where(x=>x.Price==maxPrice).Select(y=>y.City).FirstOrDefault().ToString();

            var guideByNameAysegul=db.Guide.Where(x=>x.Name=="Ayşegül" && x.Surname=="Çınar").Select(y=>y.GuideId).FirstOrDefault();
            lblAysegulLocationCount.Text=db.Location.Where(x=>x.GuideId==guideByNameAysegul).Count().ToString();
        }
    }
}
