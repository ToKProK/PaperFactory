using PaperFactory.Class;
using PaperFactory.DB;
using PaperFactory.UserControls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PaperFactory.Pages
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        int page = 0;
        int itemsOnPage = 15;

        List<Sort> sorts = new List<Sort>()
        {
            new Sort(){ id = -1, Name="Без соритровки"},
            new Sort(){ id = 0, Name="Наименование по возрастанию"},
            new Sort(){ id = 1, Name="Наименование по убыванию"},
            new Sort(){ id = 2, Name="Остаток на складе по возрастанию"},
            new Sort(){ id = 3, Name="Остаток на складе по убыванию"},
            new Sort(){ id = 4, Name="Стоимость по возрастанию"},
            new Sort(){ id = 5, Name="Стоимость по убыванию"},
        };
        public Main()
        {
            InitializeComponent();
            DBConnection.ConnectorDB();
            Filtres();
            quantity.ItemsSource = sorts;
        }
        private void FillPanel(List<Class.Material> materials)
        {    
            List<Class.Material> materiali = MainDB.GetMaterial();

            if (page < 0)
            {
                page = 0;
            }

            if (materials.Count() - page * itemsOnPage < -1 * itemsOnPage)
            {
                page--;
            }

            var view_material = materials.ToList().Skip(page*itemsOnPage).Take(itemsOnPage);
            panel.Children.Clear();
            foreach (Class.Material material in view_material)
            {
                //panel.Children.Add(new MaterialControl(material));
                // Создаем новый экземпляр MaterialControl и передаем объект material
                MaterialControl materialControl = new MaterialControl(material);

                // Добавляем новый контрол в панель
                panel.Children.Add(materialControl);
            }
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            page--;
            Filtres();
        }

        private void next_Click(object sender, RoutedEventArgs e)
        {
            page++;
            Filtres();
        }
        private void Filtres() 
        {
            List<Class.Material> materiali = MainDB.GetMaterial();
            var sort = quantity.SelectedItem as Sort;
            if (sort != null && sort.id != -1)
            {
                if (sort.id == 0)
                {
                    materiali = materiali.OrderBy(x=>x.Name).ToList();
                }
                else if (sort.id == 1)
                {
                    materiali = materiali.OrderByDescending(x=>x.Name).ToList();
                }
                else if (sort.id == 2)
                {
                    materiali = materiali.OrderBy(x => x.Quantity).ToList();
                }
                else if (sort.id == 3)
                {
                    materiali = materiali.OrderByDescending(x => x.Quantity).ToList();
                }
                else if (sort.id == 4)
                {
                    materiali = materiali.OrderBy(x => x.Price).ToList();
                }
                else if (sort.id == 5)
                {
                    materiali = materiali.OrderByDescending(x => x.Price).ToList();
                }
            }
            FillPanel(materiali);
        }
        public class Sort
        {
            public int id { get; set; }
            public string Name { get; set; }
        }
        private void quantity_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filtres();
        }
    }
}
