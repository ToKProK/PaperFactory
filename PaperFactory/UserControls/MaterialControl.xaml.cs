using System;
using System.Collections.Generic;
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

namespace PaperFactory.UserControls
{
    /// <summary>
    /// Логика взаимодействия для MaterialControl.xaml
    /// </summary>
    public partial class MaterialControl : UserControl
    {
        public Class.Material Material { get; set; }
        public MaterialControl(Class.Material material)
        {
            InitializeComponent();
            Material = material;
            this.DataContext = material;
            tipAndNaimenovanie.Content = $"{material.Type} | {material.Name}";
            min.Content = $"Минимальнок количкство: {material.min_count} { material.ed_izm}";
            postavshiki.Content = $"Количество поставщиков: {material.SuppliersCount}";
            ostatok.Content = $"Остаток: {material.Quantity}";

        }
    }
}