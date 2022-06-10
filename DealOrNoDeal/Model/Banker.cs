using System.Collections.Generic;
using System.Linq;

namespace DealOrNoDeal.Model
{
    /// <summary>
    ///     Creates a Banker object that will be able to calculate an offer
    /// </summary>
    public class Banker
    {
        #region Data members

        private IList<int> allOffers;

        #endregion

        #region Properties

        /// <summary>
        ///     Keeps Track of the minimum offer
        /// </summary>
        public int MinOffer => this.allOffers.Min();

        /// <summary>
        ///     Keeps Track of the maximum offer
        /// </summary>
        public int MaxOffer => this.allOffers.Max();

        /// <summary>
        ///     Keeps Track of the average offer
        /// </summary>
        public int AverageOffer => (int) this.allOffers.Average();

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Banker" /> class.
        /// </summary>
        public Banker()
        {
            this.allOffers = new List<int>();
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Gets the offer.
        /// </summary>
        /// <param name="dollarAmountsLeft">The dollar amounts left.</param>
        /// <param name="casesInNextRound">The cases in next round.</param>
        /// <returns> The Bankers calculated offer</returns>
        public int GetOffer(List<int> dollarAmountsLeft, int casesInNextRound)
        {
            var sum = 0;
            foreach (var amount in dollarAmountsLeft)
            {
                sum += amount;
            }

            var divideNextRoundOfCases = sum / casesInNextRound;
            var offer = divideNextRoundOfCases / dollarAmountsLeft.Count;
            offer = (offer + 50) / 100 * 100;
            this.allOffers.Add(offer);
            return offer;
        }
        #endregion
    }
}