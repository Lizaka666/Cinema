using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinema
{
    public partial class UserControl1 : UserControl
    {
        public int MovieId { get; set; }
        public UserControl1()
        {
            InitializeComponent();
        }
        public void FillData(int id, string title, string description, string duration, string ageRating, string studio, string imageFile)
        {
            MovieId = id;
            label1.Text = title;
            label2.Text = description;
            label3.Text = $"{duration} мин.";
            label4.Text = ageRating;
            label5.Text = "Студия: "+studio;

            // Путь к папке с картинками проекта
            string folderPath = Path.Combine(Application.StartupPath, "Images");
            string fullPath = Path.Combine(folderPath, imageFile ?? "");

            if (!string.IsNullOrEmpty(imageFile) && File.Exists(fullPath))
            {
                pictureBox4.Image = Image.FromFile(fullPath);
            }
            else
            {
                // Ваша заглушка, если картинки нет
                pictureBox4.Image = Properties.Resources.Default;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
