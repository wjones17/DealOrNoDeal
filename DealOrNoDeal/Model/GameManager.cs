using System.Collections.Generic;

namespace DealOrNoDeal.Model
{
    /// <summary>Handles the management of the actual game play.</summary>
    public class GameManager
    {
        #region Data members

        /// <summary>
        ///     The roundmanager to manage the creation of rounds
        /// </summary>
        public readonly RoundManager RoundManager;

        /// <summary>
        ///     The briefcaseManager to manage creating briefcases
        /// </summary>
        public readonly BriefCaseManager BriefCaseManager;

        private readonly IList<BriefCase> briefCases;
        private readonly IList<Round> gameRounds;
        private readonly Banker banker;

        #endregion

        #region Properties

        /// <summary>
        ///     Keeps up with the Player's Briefcase
        /// </summary>
        public BriefCase PlayerBriefCase { get; set; }

        /// <summary>
        ///     Keeps up with the round that the player is currently on
        /// </summary>
        public int CurrentRound { get; set; }

        /// <summary>
        ///     Keeps up with the Number of cases to open in this current round
        /// </summary>
        public int NumberOfCasesToOpen { get; set; }

        /// <summary>
        ///     Keeps up with the Current offer from the banker
        /// </summary>
        public double CurrentOffer { get; private set; }

        /// <summary>
        ///     Keeps up with the Minimum  offer from the banker
        /// </summary>
        public double MinOffer => this.banker.MinOffer;

        /// <summary>
        ///     Keeps up with the Maximum offer from the banker
        /// </summary>
        public double MaxOffer => this.banker.MaxOffer;

        /// <summary>
        ///     Keeps up with the Average offer from the banker
        /// </summary>
        public double AverageOffer => this.banker.AverageOffer;

        /// <summary>
        ///     Keeps up with the Final Round from the Rounds that are to be created later
        /// </summary>
        public int FinalRound { get; private set; }

        /// <summary>
        ///     Determines the Number of Rounds to be played
        /// </summary>
        public NumberOfRounds Rounds { get; set; }

        /// <summary>
        ///     Determines the winnings to be won
        /// </summary>
        public DollarAmount DollarRange { get; set; }

        /// <summary>
        ///     Used to create Labels in the xaml
        /// </summary>
        public IList<int> DollarAmounts { get; }

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="GameManager" /> class.
        ///     Creates a List of 26 BriefCases with an Id and a Dollar amount stored in each one
        /// </summary>
        public GameManager()
        {
            this.BriefCaseManager = new BriefCaseManager();
            this.RoundManager = new RoundManager();
            this.banker = new Banker();

            this.setUpGameplay();

            this.DollarAmounts = this.BriefCaseManager.CreateDollarAmounts(this.DollarRange);
            this.gameRounds = this.RoundManager.CreateRounds(this.Rounds);

            this.briefCases = this.BriefCaseManager.CreateBriefCases(this.DollarRange, this.Rounds);

            this.FinalRound = this.gameRounds[this.gameRounds.Count - 1].RoundNumber;
            this.CurrentRound = 1;
            this.NumberOfCasesToOpen = this.gameRounds[0].NumberOfCasesToOpen;

            this.PlayerBriefCase = null;

            this.CurrentOffer = 0;
        }

        #endregion

        #region Methods

        private void setUpGameplay()
        {
            this.Rounds = NumberOfRounds.Ten;
            this.DollarRange = DollarAmount.Regular;
        }

        /// <summary>
        ///     Gets the last remaining briefcase and returns it.
        /// </summary>
        /// <returns> The last briefCase</returns>
        public BriefCase GetLastBriefCase()
        {
            if (this.briefCases.Count == 1)
            {
                return this.briefCases[0];
            }

            return null;
        }

        /// <summary>
        ///     Removes the specified briefcase from play.
        /// </summary>
        /// <param name="id">The id of the briefcase to remove from play.</param>
        /// <returns>Dollar amount stored in the case, or -1 if case not found.</returns>
        public int RemoveBriefcaseFromPlay(int id)
        {
            foreach (var briefCase in this.briefCases)
            {
                if (briefCase.Id == id)
                {
                    this.briefCases.Remove(briefCase);
                    return briefCase.DollarAmount;
                }
            }

            return -1;
        }

        /// <summary>
        ///     Gets the offer from the banker
        /// </summary>
        /// <returns> The bankers offer</returns>
        public int GetOffer()
        {
            var casesInNextRound = this.gameRounds[this.CurrentRound].NumberOfCasesToOpen;
            var dollarAmountsLeft = new List<int>();
            var playerBriefCaseDollarAmount = this.PlayerBriefCase.DollarAmount;
            foreach (var briefCase in this.briefCases)
            {
                var amount = briefCase.DollarAmount;
                dollarAmountsLeft.Add(amount);
            }

            dollarAmountsLeft.Add(playerBriefCaseDollarAmount);
            var offer = this.banker.GetOffer(dollarAmountsLeft, casesInNextRound);
            this.CurrentOffer = offer;
            return offer;
        }

        /// <summary>
        ///     Moves to next round by incrementing Round property and setting
        ///     initial number of cases for that round
        ///     Precondition: None
        ///     Post-condition: CurrentRound == CurrentRound@prev + 1 AND NumberOfCasesToOpen  == (number of cases to open in the
        ///     next round)
        /// </summary>
        public void MoveToNextRound()
        {
            this.NumberOfCasesToOpen = this.gameRounds[this.CurrentRound].NumberOfCasesToOpen;
            this.CurrentRound += 1;
        }

        #endregion
    }
}