using Cinema.AppData;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinema
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            
            InitializeComponent();
            //AppConnect.model1 = new CinemaOnlineEntities(); //колледж
            AppConnect.model2 = new CinemaOnlineEntities2(); //дом
            LoadMoviesToPanel();
        }

        private void LoadMoviesToPanel()
        {
            try
            {
                // 1. Очищаем панель перед загрузкой
                flowLayoutPanel1.Controls.Clear();

                // 2. Берем данные напрямую из вашего объекта базы (AppConnect.model2)
                // .ToList() выгружает данные из БД в память
                var movies = AppConnect.model2.FilmInfo.Include(x => x.AgeRating).Include(x => x.Studio).ToList();

                foreach (var movie in movies)
                {
                    // 3. Создаем ваш UserControl
                    UserControl1 user = new UserControl1();

                    // 4. Передаем данные из свойств объекта movie
                    // Больше не нужно писать названия колонок в кавычках
                    user.FillData(
                        movie.FilmID,
                        movie.Name,
                        movie.Description,
                        movie.DurationMin.ToString(),
                        movie.AgeRating.Name,
                        movie.Studio.Name,
                        movie.Image // Если в базе NULL, придет пустая строка или null
                    );

                    // 5. Событие клика
                    user.Click += (s, e) => {
                        MessageBox.Show("Выбран фильм: " + movie.Name);
                    };

                    // 6. Добавляем в FlowLayoutPanel
                    flowLayoutPanel1.Controls.Add(user);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке из Entity Framework: " + ex.Message);
            }
        }
    }
}
