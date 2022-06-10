using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using DealOrNoDeal.Model;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace DealOrNoDeal.View
{
    /// <summary>
    ///     An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DealOrNoDealPage
    {
        #region Data members

        /// <summary>
        ///     The application height
        /// </summary>
        public const int ApplicationHeight = 500;

        /// <summary>
        ///     The application width
        /// </summary>
        public const int ApplicationWidth = 500;

        private IList<Button> briefcaseButtons;
        private IList<Border> dollarAmountLabels;
        private GameManager gameManager;
        private int countBriefCasesSelected;

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="DealOrNoDealPage" /> class.
        /// </summary>
        public DealOrNoDealPage()
        {
            this.InitializeComponent();
            this.initializeUiDataAndControls();
        }

        #endregion

        #region Methods

        private void initializeUiDataAndControls()
        {
            this.setPageSize();
            this.gameManager = new GameManager();
            this.countBriefCasesSelected = 0;

            this.briefcaseButtons = new List<Button>();
            this.dollarAmountLabels = new List<Border>();
            this.buildBriefcaseButtonCollection();
            this.buildDollarAmountLabelCollection();
            this.collapseDealAndNoDealButtons();
            this.updateWelcomeMessage();
        }

        private void setPageSize()
        {
            ApplicationView.PreferredLaunchViewSize = new Size {Width = ApplicationWidth, Height = ApplicationHeight};
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(ApplicationWidth, ApplicationHeight));
        }

        private void buildBriefcaseButtonCollection()
        {
            this.briefcaseButtons.Clear();
            this.buildBriefcaseButtons();
        }

        private void buildBriefcaseButtons()
        {
            this.briefcaseButtons.Clear();
            if (this.gameManager.Rounds.Equals(NumberOfRounds.Quickplay))
            {
                this.buildQuickplayButtons();
                this.hideAndDisableExtraBriefcaseButtonsForQuickplay();
            }
            else
            {
                this.buildRegularAmountOfButtons();
            }

            this.storeBriefCaseIndexInControlsTagProperty();
        }

        private void buildRegularAmountOfButtons()
        {
            this.briefcaseButtons.Add(this.case0);
            this.briefcaseButtons.Add(this.case1);
            this.briefcaseButtons.Add(this.case2);
            this.briefcaseButtons.Add(this.case3);
            this.briefcaseButtons.Add(this.case4);
            this.briefcaseButtons.Add(this.case5);
            this.briefcaseButtons.Add(this.case6);
            this.briefcaseButtons.Add(this.case7);
            this.briefcaseButtons.Add(this.case8);
            this.briefcaseButtons.Add(this.case9);
            this.briefcaseButtons.Add(this.case10);
            this.briefcaseButtons.Add(this.case11);
            this.briefcaseButtons.Add(this.case12);
            this.briefcaseButtons.Add(this.case13);
            this.briefcaseButtons.Add(this.case14);
            this.briefcaseButtons.Add(this.case15);
            this.briefcaseButtons.Add(this.case16);
            this.briefcaseButtons.Add(this.case17);
            this.briefcaseButtons.Add(this.case18);
            this.briefcaseButtons.Add(this.case19);
            this.briefcaseButtons.Add(this.case20);
            this.briefcaseButtons.Add(this.case21);
            this.briefcaseButtons.Add(this.case22);
            this.briefcaseButtons.Add(this.case23);
            this.briefcaseButtons.Add(this.case24);
            this.briefcaseButtons.Add(this.case25);
        }

        private void buildQuickplayButtons()
        {
            this.briefcaseButtons.Add(this.case0);
            this.briefcaseButtons.Add(this.case1);
            this.briefcaseButtons.Add(this.case2);
            this.briefcaseButtons.Add(this.case3);
            this.briefcaseButtons.Add(this.case4);
            this.briefcaseButtons.Add(this.case5);
            this.briefcaseButtons.Add(this.case6);
            this.briefcaseButtons.Add(this.case7);
            this.briefcaseButtons.Add(this.case8);
            this.briefcaseButtons.Add(this.case9);
            this.briefcaseButtons.Add(this.case10);
            this.briefcaseButtons.Add(this.case11);
            this.briefcaseButtons.Add(this.case12);
            this.briefcaseButtons.Add(this.case13);
            this.briefcaseButtons.Add(this.case14);
            this.briefcaseButtons.Add(this.case15);
            this.briefcaseButtons.Add(this.case16);
            this.briefcaseButtons.Add(this.case17);
        }

        private void hideAndDisableExtraBriefcaseButtonsForQuickplay()
        {
            var case18Button = this.case18;
            case18Button.Visibility = Visibility.Collapsed;
            case18Button.IsEnabled = false;
            var case19Button = this.case19;
            case19Button.Visibility = Visibility.Collapsed;
            case19Button.IsEnabled = false;
            var case20Button = this.case20;
            case20Button.Visibility = Visibility.Collapsed;
            case20Button.IsEnabled = false;
            var case21Button = this.case21;
            case21Button.Visibility = Visibility.Collapsed;
            case21Button.IsEnabled = false;
            var case22Button = this.case22;
            case22Button.Visibility = Visibility.Collapsed;
            case22Button.IsEnabled = false;
            var case23Button = this.case23;
            case23Button.Visibility = Visibility.Collapsed;
            case23Button.IsEnabled = false;
            var case24Button = this.case24;
            case24Button.Visibility = Visibility.Collapsed;
            case24Button.IsEnabled = false;
            var case25Button = this.case25;
            case25Button.Visibility = Visibility.Collapsed;
            case25Button.IsEnabled = false;
        }

        private void storeBriefCaseIndexInControlsTagProperty()
        {
            for (var i = 0; i < this.briefcaseButtons.Count; i++)
            {
                this.briefcaseButtons[i].Tag = i;
            }
        }

        private void buildDollarAmountLabelCollection()
        {
            if (this.gameManager.DollarRange.Equals(DollarAmount.Quickplay))
            {
                this.buildQuickplayAmountOfLabels();
            }
            else
            {
                this.buildRegularAmountOfLabels();
            }

            for (var i = 0; i < this.dollarAmountLabels.Count; i++)
            {
                var moneyLabel = this.dollarAmountLabels[i].Child as TextBlock;
                var amount = this.gameManager.DollarAmounts[i];

                if (moneyLabel != null)
                {
                    moneyLabel.Text = amount.ToString("C");
                }
            }
        }

        private void buildQuickplayAmountOfLabels()
        {
            this.dollarAmountLabels.Clear();

            this.dollarAmountLabels.Add(this.label0Border);
            this.dollarAmountLabels.Add(this.label1Border);
            this.dollarAmountLabels.Add(this.label2Border);
            this.dollarAmountLabels.Add(this.label3Border);
            this.dollarAmountLabels.Add(this.label4Border);
            this.dollarAmountLabels.Add(this.label5Border);
            this.dollarAmountLabels.Add(this.label6Border);
            this.dollarAmountLabels.Add(this.label7Border);
            this.dollarAmountLabels.Add(this.label8Border);
            this.dollarAmountLabels.Add(this.label9Border);
            this.dollarAmountLabels.Add(this.label10Border);
            this.dollarAmountLabels.Add(this.label11Border);
            this.dollarAmountLabels.Add(this.label12Border);
            this.dollarAmountLabels.Add(this.label13Border);
            this.dollarAmountLabels.Add(this.label14Border);
            this.dollarAmountLabels.Add(this.label15Border);
            this.dollarAmountLabels.Add(this.label16Border);
            this.dollarAmountLabels.Add(this.label17Border);

            this.blackOutExtraLabelsForQuickplay();
        }

        private void blackOutExtraLabelsForQuickplay()
        {
            this.label18Border.Background = new SolidColorBrush(Colors.Black);
            this.label19Border.Background = new SolidColorBrush(Colors.Black);
            this.label20Border.Background = new SolidColorBrush(Colors.Black);
            this.label21Border.Background = new SolidColorBrush(Colors.Black);
            this.label22Border.Background = new SolidColorBrush(Colors.Black);
            this.label23Border.Background = new SolidColorBrush(Colors.Black);
            this.label24Border.Background = new SolidColorBrush(Colors.Black);
            this.label25Border.Background = new SolidColorBrush(Colors.Black);
        }

        private void buildRegularAmountOfLabels()
        {
            this.dollarAmountLabels.Clear();

            this.dollarAmountLabels.Add(this.label0Border);
            this.dollarAmountLabels.Add(this.label1Border);
            this.dollarAmountLabels.Add(this.label2Border);
            this.dollarAmountLabels.Add(this.label3Border);
            this.dollarAmountLabels.Add(this.label4Border);
            this.dollarAmountLabels.Add(this.label5Border);
            this.dollarAmountLabels.Add(this.label6Border);
            this.dollarAmountLabels.Add(this.label7Border);
            this.dollarAmountLabels.Add(this.label8Border);
            this.dollarAmountLabels.Add(this.label9Border);
            this.dollarAmountLabels.Add(this.label10Border);
            this.dollarAmountLabels.Add(this.label11Border);
            this.dollarAmountLabels.Add(this.label12Border);
            this.dollarAmountLabels.Add(this.label13Border);
            this.dollarAmountLabels.Add(this.label14Border);
            this.dollarAmountLabels.Add(this.label15Border);
            this.dollarAmountLabels.Add(this.label16Border);
            this.dollarAmountLabels.Add(this.label17Border);
            this.dollarAmountLabels.Add(this.label18Border);
            this.dollarAmountLabels.Add(this.label19Border);
            this.dollarAmountLabels.Add(this.label20Border);
            this.dollarAmountLabels.Add(this.label21Border);
            this.dollarAmountLabels.Add(this.label22Border);
            this.dollarAmountLabels.Add(this.label23Border);
            this.dollarAmountLabels.Add(this.label24Border);
            this.dollarAmountLabels.Add(this.label25Border);
        }

        private void collapseDealAndNoDealButtons()
        {
            this.dealButton.Visibility = Visibility.Collapsed;
            this.noDealButton.Visibility = Visibility.Collapsed;
        }

        private void updateWelcomeMessage()
        {
            var version = this.gameManager.DollarRange.ToString();
            this.roundLabel.Text = "Deal or No Deal!!";
            this.casesToOpenLabel.Text = version + " Version:";
            if (this.gameManager.Rounds.Equals(NumberOfRounds.Seven))
            {
                this.casesToOpenLabel.Text += " Seven Rounds";
            }
            else if (this.gameManager.Rounds.Equals(NumberOfRounds.Seven))
            {
                this.casesToOpenLabel.Text += " Ten Rounds";
            }
            else if (this.gameManager.Rounds.Equals(NumberOfRounds.Quickplay))
            {
                this.casesToOpenLabel.Text += " Five Rounds";
            }
        }

        private void briefcase_Click(object sender, RoutedEventArgs e)
        {
            if (!(sender is Button briefcaseSelected))
            {
                return;
            }

            this.hideAndDisableSelectedBriefCase(briefcaseSelected);
            this.handleBriefCaseSelectedAndUpdateInfo(briefcaseSelected);
        }

        private void hideAndDisableSelectedBriefCase(Button briefcaseSelected)
        {
            briefcaseSelected.IsEnabled = false;
            briefcaseSelected.Visibility = Visibility.Collapsed;
        }

        private void handleBriefCaseSelectedAndUpdateInfo(Button briefcaseSelected)
        {
            var briefCaseId = this.getBriefcaseID(briefcaseSelected);

            if (this.gameManager.CurrentRound == this.gameManager.FinalRound)
            {
                _ = this.updateWinningsForSelectedBriefcaseAsync(briefCaseId);
            }
            else if (this.gameManager.PlayerBriefCase == null)
            {
                var selectedBriefCaseAmount = this.gameManager.RemoveBriefcaseFromPlay(briefCaseId);

                this.gameManager.PlayerBriefCase = new BriefCase(briefCaseId, selectedBriefCaseAmount);
                this.gameManager.RemoveBriefcaseFromPlay(this.gameManager.PlayerBriefCase.Id);
                this.summaryOutput.Text = "Your case :" + this.gameManager.PlayerBriefCase.Id;
                this.updateCurrentRoundInformation();
            }
            else
            {
                this.countBriefCasesSelected++;
                var selectedBriefCaseAmount = this.gameManager.RemoveBriefcaseFromPlay(briefCaseId);
                this.updateCurrentRoundInformation();
                this.findAndGrayOutGameDollarLabel(selectedBriefCaseAmount);
            }
        }

        private async Task updateWinningsForSelectedBriefcaseAsync(int briefCaseId)
        {
            if (briefCaseId == this.gameManager.PlayerBriefCase.Id)
            {
                this.summaryOutput.Text = "Congrats! You win: " +
                                          this.gameManager.PlayerBriefCase.DollarAmount.ToString("C") + "\r\n";
                this.summaryOutput.Text += "Game Over";
                this.disableRemainingBriefCases();
                await this.askUserForRestartAsync();
            }
            else
            {
                var selectedBriefCaseAmount = this.gameManager.RemoveBriefcaseFromPlay(briefCaseId);
                this.summaryOutput.Text = "Congrats! You win: " +
                                          selectedBriefCaseAmount.ToString("C") + "\r\n";
                this.summaryOutput.Text += "Game Over";
                this.disableRemainingBriefCases();
                await this.askUserForRestartAsync();
            }
        }

        private async Task askUserForRestartAsync()
        {
            var askDialogue = new ContentDialog {
                Title = "Do you Want to Play Again?",
                Content = "Restart Game",
                PrimaryButtonText = "Yes",
                SecondaryButtonText = "No"
            };

            var result = await askDialogue.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                _ = CoreApplication.RequestRestartAsync(" ");
            }
            else if (result == ContentDialogResult.Secondary)
            {
                Application.Current.Exit();
            }
        }

        private int getBriefcaseID(Button selectedBriefCase)
        {
            return (int) selectedBriefCase.Tag + 1;
        }

        private void updateCurrentRoundInformation()
        {
            this.roundLabel.Text = "Round " + this.gameManager.CurrentRound + ": " +
                                   this.gameManager.NumberOfCasesToOpen + " Cases to open";
            this.updateCasesToOpenLabel();

            if (this.gameManager.CurrentRound == this.gameManager.FinalRound)
            {
                this.disableAndHideLastBriefCase();
                this.updateTextAndButtonsForFinalRound();
            }
            else if (this.countBriefCasesSelected == this.gameManager.NumberOfCasesToOpen)
            {
                this.makeDealAndNoDealButtonsVisible();
                this.disableRemainingBriefCases();
                this.gameManager.GetOffer();
                this.updateSummary();
            }
        }

        private void updateCasesToOpenLabel()
        {
            if ((this.gameManager.NumberOfCasesToOpen - this.countBriefCasesSelected) == 1)
            {
                this.casesToOpenLabel.Text = this.gameManager.NumberOfCasesToOpen - this.countBriefCasesSelected +
                                             " more case to open";
            }
            else
            {
                this.casesToOpenLabel.Text = this.gameManager.NumberOfCasesToOpen - this.countBriefCasesSelected +
                                             " more cases to open";
            }
        }

        private void findAndGrayOutGameDollarLabel(int amount)
        {
            foreach (var dollarAmountLabel in this.dollarAmountLabels)
            {
                if (grayOutLabelIfMatchesDollarAmount(amount, dollarAmountLabel))
                {
                    break;
                }
            }
        }

        private static bool grayOutLabelIfMatchesDollarAmount(int amount, Border dollarAmountLabel)
        {
            var matched = false;

            if (dollarAmountLabel.Child is TextBlock dollarTextBlock)
            {
                var labelAmount = int.Parse(dollarTextBlock.Text, NumberStyles.Currency);
                if (labelAmount == amount)
                {
                    dollarAmountLabel.Background = new SolidColorBrush(Colors.Gray);
                    matched = true;
                }
            }

            return matched;
        }

        private void disableAndHideLastBriefCase()
        {
            foreach (var button in this.briefcaseButtons)
            {
                button.IsEnabled = false;
                button.Visibility = Visibility.Collapsed;
            }
        }

        private void updateTextAndButtonsForFinalRound()
        {
            this.roundLabel.Text = "This is the Final Round";
            this.casesToOpenLabel.Text = "Please Select a Case";
            this.summaryOutput.Text =
                "Min Offer:" + this.gameManager.MinOffer.ToString("C") + " Max Offer: " +
                this.gameManager.MaxOffer.ToString("C");

            this.moveLastBriefCasesToTheMiddle();
            this.enableAndMakeLastTwoBriefcasesVisible();
        }

        private void enableAndMakeLastTwoBriefcasesVisible()
        {
            this.getLastBriefCaseButton().Visibility = Visibility.Visible;
            this.getLastBriefCaseButton().IsEnabled = true;
            this.getPlayerBriefCaseButton().Visibility = Visibility.Visible;
            this.getPlayerBriefCaseButton().IsEnabled = true;
        }

        private void moveLastBriefCasesToTheMiddle()
        {
            var stack = this.case11.Parent as StackPanel;
            var playerStack = this.getPlayerBriefCaseButton().Parent as StackPanel;
            var playerButton = this.getPlayerBriefCaseButton();
            var lastButton = this.getLastBriefCaseButton();
            stack = this.removeChildrenFromStackPanel(stack, playerStack);

            this.compareLastTwoBriefCaseIds(playerButton, lastButton, stack);
        }

        private StackPanel removeChildrenFromStackPanel(StackPanel stack, StackPanel playerStack)
        {
            if (stack.Equals(playerStack))
            {
                stack = playerStack;
                stack.Children.Remove(this.getPlayerBriefCaseButton());
            }
            else if (playerStack != null)
            {
                playerStack.Children.Remove(this.getPlayerBriefCaseButton());
            }

            var lastCaseStack = this.getLastBriefCaseButton().Parent as StackPanel;
            if (lastCaseStack != null)
            {
                lastCaseStack.Children.Remove(this.getLastBriefCaseButton());
            }

            return stack;
        }

        private void compareLastTwoBriefCaseIds(Button playerButton, Button lastButton, StackPanel stack)
        {
            if ((int) playerButton.Tag > (int) lastButton.Tag)
            {
                stack.Children.Add(lastButton);
                stack.Children.Add(playerButton);
            }
            else
            {
                stack.Children.Add(playerButton);
                stack.Children.Add(lastButton);
            }
        }

        private Button getPlayerBriefCaseButton()
        {
            foreach (var button in this.briefcaseButtons)
            {
                var tag = (int) button.Tag;
                if (tag == this.gameManager.PlayerBriefCase.Id - 1)
                {
                    return button;
                }
            }

            return null;
        }

        private Button getLastBriefCaseButton()
        {
            Button button = null;
            foreach (var but in this.briefcaseButtons)
            {
                var tag = (int) but.Tag;
                if (tag == this.gameManager.GetLastBriefCase().Id - 1)
                {
                    button = but;
                }
            }

            return button;
        }

        private void makeDealAndNoDealButtonsVisible()
        {
            this.dealButton.Visibility = Visibility.Visible;
            this.noDealButton.Visibility = Visibility.Visible;
        }

        private void disableRemainingBriefCases()
        {
            foreach (var button in this.briefcaseButtons)
            {
                button.IsEnabled = false;
            }
        }

        private void updateSummary()
        {
            this.summaryOutput.Text =
                "Min Offer:" + this.gameManager.MinOffer.ToString("C") + " Max Offer: " +
                this.gameManager.MaxOffer.ToString("C") + "\r\n";
            this.summaryOutput.Text += "Current Offer:" + this.gameManager.CurrentOffer.ToString("C") + "\r\n";
            this.summaryOutput.Text += "Deal or No Deal?";
        }

        private void dealButton_Click(object sender, RoutedEventArgs e)
        {
            this.summaryOutput.Text = "Your case contained: " +
                                      this.gameManager.PlayerBriefCase.DollarAmount.ToString("C") + "\r\n";
            this.summaryOutput.Text += "Accepted Offer: " + this.gameManager.CurrentOffer.ToString("C") + "\r\n";
            this.summaryOutput.Text += "Game Over";
            this.collapseDealAndNoDealButtons();
            _ = this.askUserForRestartAsync();
        }

        private void noDealButton_Click(object sender, RoutedEventArgs e)
        {
            this.gameManager.MoveToNextRound();
            this.countBriefCasesSelected = 0;
            this.collapseDealAndNoDealButtons();
            this.enableRemainingBriefCases();
            this.updateCurrentRoundInformation();
            this.updateSummaryBasedOnIfThisIsLastRound();
        }

        private void enableRemainingBriefCases()
        {
            foreach (var button in this.briefcaseButtons)
            {
                button.IsEnabled = true;
            }
        }

        private void updateSummaryBasedOnIfThisIsLastRound()
        {
            if (this.gameManager.CurrentRound == this.gameManager.FinalRound)
            {
                this.summaryOutput.Text =
                    "Min Offer:" + this.gameManager.MinOffer.ToString("C") + " Max Offer: " +
                    this.gameManager.MaxOffer.ToString("C");
            }
            else
            {
                this.summaryOutput.Text =
                    "Min Offer:" + this.gameManager.MinOffer.ToString("C") + " Max Offer: " +
                    this.gameManager.MaxOffer.ToString("C") + "\r\n";
                this.summaryOutput.Text += "Average offer:" + this.gameManager.AverageOffer.ToString("C");
            }
        }

        #endregion
    }
}