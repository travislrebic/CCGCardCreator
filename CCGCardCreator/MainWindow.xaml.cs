using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace CCGCardCreator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<CardFrontSelection> CardFrontSelections = new ObservableCollection<CardFrontSelection>();
        public MainWindow()
        {
            InitializeComponent();
            CardFrontSelections.Add(new CardFrontSelection("Basic Minion", "Resources/HS_Basic_Minion_Card_Blank.png"));
            CardFrontSelections.Add(new CardFrontSelection("Common Minion", "Resources/HS_Common_Minion_Card_Blank.png"));
            CardFrontSelections.Add(new CardFrontSelection("Rare Minion", "Resources/HS_Rare_Minion_Card_Blank.png"));
            CardFrontSelections.Add(new CardFrontSelection("Epic Minion", "Resources/HS_Epic_Minion_Card_Blank.png"));
            CardFrontSelections.Add(new CardFrontSelection("Legendary Minion", "Resources/HS_Legendary_Minion_Card_Blank.png"));
            CardFrontSelections.Add(new CardFrontSelection("Weapon", "Resources/HS_Weapon_Card_Blank.png"));

            ddCardType.ItemsSource = CardFrontSelections;
            ddCardType.DisplayMemberPath = "Content";
            ddCardType.SelectedIndex = 0;
            
        }


        private void ddCardType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var ImageLocation = (ddCardType.SelectedItem as CardFrontSelection).Image;
            var Image = new BitmapImage(new Uri(ImageLocation, UriKind.Relative));
            imgCardFront.Source = Image;

        }



    }
}
