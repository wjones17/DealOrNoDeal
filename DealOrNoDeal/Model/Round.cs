using System;

namespace DealOrNoDeal.Model
{
    /// <summary>
    ///     <br> Creates a Round object that will have a RoundNumber and NumberOfCasesToOpen</br>
    /// </summary>
    public class Round
    {
        #region Properties

        /// <summary>
        ///     Keeps track of the Round Number
        /// </summary>
        public int RoundNumber { get; set; }

        /// <summary>
        ///     Keeps track of the number of cases to open in each round
        /// </summary>
        public int NumberOfCasesToOpen { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Round" /> class.
        /// </summary>
        /// Precondition: roundNumber > 0 && numberOfCasesToOpen > 0
        /// Post-Condition: this.RoundNumber == roundNumber && this.NumberOfCasesToOpen == numberOfCasesToOpen
        /// <param name="roundNumber">The round number.</param>
        /// <param name="numberOfCasesToOpen">The number of cases to open.</param>
        public Round(int roundNumber, int numberOfCasesToOpen)
        {
            if (roundNumber < 0)
            {
                throw new ArgumentException("roundNumber must be > 0");
            }

            if (numberOfCasesToOpen < 0)
            {
                throw new ArgumentException("numberOfCasesToOpen must be > 0");
            }

            this.RoundNumber = roundNumber;
            this.NumberOfCasesToOpen = numberOfCasesToOpen;
        }

        #endregion
    }
}