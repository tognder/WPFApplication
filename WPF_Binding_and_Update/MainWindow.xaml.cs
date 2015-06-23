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

namespace WPF_Binding_and_Update
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

        bool mlsAddMode = false;

        private BindingListCollectionView employeeView;

        NotWindEmplyeeDataContext no = new NotWindEmplyeeDataContext();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var items = from item in no.Employees
                        orderby item.LastName
                        select item;
            this.DataContext = items;

            //turn Collection of employee int BindindListCollectionView
            //This is need for add/delete/edit

            this.employeeView = (BindingListCollectionView)
                (CollectionViewSource.GetDefaultView(items));
        }

        private void Savebtn_Click(object sender, RoutedEventArgs e)
        {
            this.no.SubmitChanges();
            mlsAddMode = false;
        }

        private void Deletebtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Delete this Emp?", "Delete", MessageBoxButton.YesNo,
                MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                this.employeeView.RemoveAt(this.employeeView.CurrentPosition);
                no.SubmitChanges();
            }
            mlsAddMode = false;
        }

        private void Addbtn_Click(object sender, RoutedEventArgs e)
        {
            //set Add Flag 
            mlsAddMode = true;
            //Create New emp

            Employee newEmp = (Employee)(this.employeeView.AddNew());
           
            //Fill the defulat value 
            newEmp.FirstName = "<new>";
            newEmp.LastName = "<new>";
            newEmp.Title = titletxtbox.Text;
            newEmp.Country = cotrytextbox.Text;
            this.employeeView.CommitNew();
            this.emplist.ScrollIntoView(newEmp);
            

        }

        private void Cancelbtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (mlsAddMode)
                {
                    this.employeeView.CancelNew();
                    this.employeeView.Remove(this.employeeView.CurrentItem);
                }
                else
                {
                    this.employeeView.CancelEdit();
                    no.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, no.GetChangeSet());
                    this.employeeView.Refresh();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
            mlsAddMode = false;
        }

        
    }
}
