﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace BarkodSatışSistemi
{
    class Yazdir
    {
        public int? islemNo { get; set; }

        public Yazdir(int? islemno)
        {
            islemNo = islemno;
        }

        PrintDocument pd = new PrintDocument();
        public void yazdirmayabasla()
        {
            try
            {
                pd.PrintPage += Pd_PrintPage;
                pd.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            BarkodDBEntities db = new BarkodDBEntities();
            var isyer = db.Sabit.FirstOrDefault();
            var liste = db.Satis.Where(x => x.IslemNo == islemNo).ToList();
            if(isyer != null && liste != null)
            {
                int kagituzunluk = 120;
                for (int i = 0; i < liste.Count; i++)
                {
                    kagituzunluk += 15;
                }
                PaperSize ps58 = new PaperSize("58mm termal", 220, kagituzunluk + 80);
                pd.DefaultPageSettings.PaperSize = ps58;


                Font fontBasalik = new Font("calibri", 10, FontStyle.Bold);
                Font fontBilgi = new Font("calibri", 8, FontStyle.Bold);
                Font fontIcerikBaslik = new Font("calibri", 8, FontStyle.Underline);
                StringFormat ortala = new StringFormat(StringFormatFlags.FitBlackBox);
                ortala.Alignment = StringAlignment.Center;
                RectangleF rcUnvanKonum = new RectangleF(0, 20, 220, 20);

                e.Graphics.DrawString(isyer.Unvan, fontBasalik, Brushes.Black, rcUnvanKonum,ortala);
                e.Graphics.DrawString("Telefon : "+isyer.Telefon, fontBasalik, Brushes.Black, new Point(5,45));
                e.Graphics.DrawString("Işlem No : "+islemNo.ToString() ,fontBilgi, Brushes.Black, new Point(5, 60));
                e.Graphics.DrawString("Tarih : " + DateTime.Now, fontBilgi, Brushes.Black, new Point(5, 75));
                e.Graphics.DrawString("-----------------------------------------------", fontBilgi, Brushes.Black, new Point(5, 90));


                e.Graphics.DrawString("Ürün Adı", fontIcerikBaslik, Brushes.Black, new Point(5, 105));
                e.Graphics.DrawString("Miktar", fontIcerikBaslik, Brushes.Black, new Point(100, 105));
                e.Graphics.DrawString("Fiyat", fontIcerikBaslik, Brushes.Black, new Point(140, 105));
                e.Graphics.DrawString("Tutar", fontIcerikBaslik, Brushes.Black, new Point(180, 105));


                int yukseklik = 120;
                double geneltoplam = 0;
                foreach (var item in liste)
                {
                    e.Graphics.DrawString(item.UrunAd, fontBilgi, Brushes.Black, new Point(5, yukseklik));
                    e.Graphics.DrawString(item.Miktar.ToString(), fontBilgi, Brushes.Black, new Point(100, yukseklik));
                    e.Graphics.DrawString(Convert.ToDouble(item.SatisFiyat).ToString("C2"), fontBilgi, Brushes.Black, new Point(140, yukseklik));
                    e.Graphics.DrawString(Convert.ToDouble(item.Toplam).ToString("C2"), fontBilgi, Brushes.Black, new Point(180, yukseklik));
                    yukseklik += 15;

                    geneltoplam += Convert.ToDouble(item.Toplam);
                }
                    e.Graphics.DrawString("-----------------------------------------------\n", fontBilgi, Brushes.Black, new Point(5, yukseklik));
                    e.Graphics.DrawString("Toplam : "+ geneltoplam.ToString("C2"),fontBilgi ,Brushes.Black, new Point(5, yukseklik+20));
                    e.Graphics.DrawString("-----------------------------------------------\n", fontBilgi, Brushes.Black, new Point(5, yukseklik+40));
                  

                    
            }
        }
    }
}
