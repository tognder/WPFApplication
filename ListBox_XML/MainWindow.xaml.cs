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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ListBox_XML
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataTemplate tmpl;
            tmpl = (DataTemplate)FindResource("moreData");
            if (tmpl != null)
                listdata.ItemTemplate = tmpl;
 
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DataTemplate tmepl;
            tmepl = (DataTemplate)FindResource("LessData");
            if (tmepl != null)
                listdata.ItemTemplate = tmepl;
        }
    }
}
