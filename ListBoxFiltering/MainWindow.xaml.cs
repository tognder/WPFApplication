using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace ListBoxFiltering
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

        private void SortTheData(object sender, RoutedEventArgs e)
        {
            if(contatcList != null)
            {
                ICollectionView dataView =
                    CollectionViewSource.GetDefaultView(contatcList.ItemsSource);
                dataView.SortDescriptions.Clear();
                dataView.SortDescriptions.Add(new SortDescription((sender as RadioButton).Tag.ToString(),ListSortDirection.Ascending));
                contatcList.ItemsSource = dataView;
                    
            }
        }

        private void FilterData()
        {
            if(contatcList !=null)
            {
                ICollectionView dataView = CollectionViewSource.GetDefaultView(contatcList.ItemsSource);

                dataView.Filter = cust => ((Customer)cust).CompanyName.ToLower().StartsWith(txtLast.Text.ToLower());
                if(dataView.IsEmpty)
                {
                    MessageBox.Show("No Data Found");
                }
                else
                {
                    contatcList.ItemsSource = dataView;
                }
               
            }
        }

        private void serchbtn_Click(object sender, RoutedEventArgs e)
        {
            FilterData();
        }

        private void txtLast_TextChanged(object sender, TextChangedEventArgs e)
        {
            FilterData();
        }

    }
}
