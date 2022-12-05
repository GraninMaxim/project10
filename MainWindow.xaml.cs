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
using System.Collections;

namespace project10
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

        List<int> arrayList = new();

        private void Create_and_Fill_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int itemsCount = Int32.Parse(inpItemsCount.Text);
                Random rnd = new();
                for (int i = 0; i < itemsCount; i++)
                {
                    arrayList.Add(rnd.Next(-100, 100));
                }
                sourceData.ItemsSource = arrayList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            sourceData.ItemsSource = null;
            currentData.ItemsSource = null;
            inpItemsCount.Clear();
            arrayList.Clear();
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            int max = arrayList[0];
            int ind = 0;
            for (int i = 1; i < arrayList.Count; i++)
            {
                if (max < arrayList[i])
                {
                    max = arrayList[i];
                    ind = i;
                }
            }
            int firstItem = arrayList[0];
            arrayList[0] = max;
            arrayList[ind] = firstItem;
            currentData.ItemsSource = arrayList;
        }

        private void About_Program_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("В массиве чисел найти наибольший элемент и поменять его местами с первым " +
                "элементом.", "О программе", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
