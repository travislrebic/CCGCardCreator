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
        ObservableCollection<CardStats> Cards = new ObservableCollection<CardStats>();
        public MainWindow()
        {
            // Window Specific code
            InitializeComponent();
            
            // Create the card front selections
            CardFrontSelections.Add(new CardFrontSelection("Basic Minion", "Resources/HS_Basic_Minion_Card_Blank.png"));
            CardFrontSelections.Add(new CardFrontSelection("Common Minion", "Resources/HS_Common_Minion_Card_Blank.png"));
            CardFrontSelections.Add(new CardFrontSelection("Rare Minion", "Resources/HS_Rare_Minion_Card_Blank.png"));
            CardFrontSelections.Add(new CardFrontSelection("Epic Minion", "Resources/HS_Epic_Minion_Card_Blank.png"));
            CardFrontSelections.Add(new CardFrontSelection("Legendary Minion", "Resources/HS_Legendary_Minion_Card_Blank.png"));
            CardFrontSelections.Add(new CardFrontSelection("Weapon", "Resources/HS_Weapon_Card_Blank.png"));

            // Hook up CardFrontSelections to the ddCardType dropdown
            ddCardType.ItemsSource = CardFrontSelections;
            ddCardType.DisplayMemberPath = "Content";
            ddCardType.SelectedIndex = 0;

            // Hook up Card Collection
            ddCardSelect.ItemsSource = Cards;
            ddCardSelect.DisplayMemberPath = "CardName";

            // Set initial card stats to blank
            txtCardName.Text = "";
            txtCardText.Text = "";
            txtManaCost.Text = "";
            txtPower.Text = "";
            txtToughness.Text = "";
        }
        

        private void ddCardType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var ImageLocation = (ddCardType.SelectedItem as CardFrontSelection).Image;
            var Image = new BitmapImage(new Uri(ImageLocation, UriKind.Relative));
            imgCardFront.Source = Image;
            
        }
        private void ddCardSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnSaveCard_Click(object sender, RoutedEventArgs e)
        {
            // Initialize new card
            var Card = new CardStats();
            bool FoundCard = false;

            // loop through Cards and set our card to the existing card if the name matches
            foreach(var CurrentCard in Cards)
            {
                if(CurrentCard.CardName == txtCardName.Text)
                {
                    Card = CurrentCard;
                    FoundCard = true;
                    break;
                }
            }

            // Set Card values to values on form
            Card.CardName = txtCardName.Text;
            Card.CardText = txtCardText.Text;
            Card.ManaCost = txtManaCost.Text;
            Card.Power = txtPower.Text;
            Card.Toughness = txtToughness.Text;
            //Card.CardType = ddCardType.SelectedItem;

            // Add Card values to ObservableCollection if the CardName didn't already exist
            if (FoundCard == false)
            {
                Cards.Add(Card);
            }
            
        }
    }
}
