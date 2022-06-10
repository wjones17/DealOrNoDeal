using System;
using System.Collections.Generic;

namespace DealOrNoDeal.Model
{
    /// <summary>
    ///     Manages the creation of briefcases including how many briefcases and the Dollar amounts that are going in them.
    /// </summary>
    public class BriefCaseManager
    {
        #region Properties

        /// <summary>
        ///     The list of Briefcases that is created
        /// </summary>
        public IList<BriefCase> BriefCases { get; }

        /// <summary>
        ///     The list of Dollar amounts that is created
        /// </summary>
        public IList<int> DollarAmounts { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="BriefCaseManager" /> class.
        /// </summary>
        public BriefCaseManager()
        {
            this.BriefCases = new List<BriefCase>();
            this.DollarAmounts = new List<int>();
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Creates the brief cases.
        /// </summary>
        /// <param name="dollarRange">The dollar range.</param>
        /// <param name="numberOfRounds">The number of rounds.</param>
        /// <returns>The list of briefcases created from the given enum information</returns>
        public IList<BriefCase> CreateBriefCases(DollarAmount dollarRange, NumberOfRounds numberOfRounds)
        {
            if (numberOfRounds.Equals(NumberOfRounds.Quickplay))
            {
                this.createQuickplayBriefCases();
            }
            else if (dollarRange.Equals(DollarAmount.Regular) && (numberOfRounds.Equals(NumberOfRounds.Seven) ||
                                                                  numberOfRounds.Equals(NumberOfRounds.Ten)))
            {
                this.createRegularRoundBriefCases();
            }
            else if (dollarRange.Equals(DollarAmount.Syndicated) && (numberOfRounds.Equals(NumberOfRounds.Seven) ||
                                                                     numberOfRounds.Equals(NumberOfRounds.Ten)))
            {
                this.createSyndicatedRoundBriefCases();
            }

            return this.BriefCases;
        }

        private void createQuickplayBriefCases()
        {
            var briefCaseDollarAmounts = new List<int> {
                0, 5, 10, 25, 50, 75, 100, 250, 500, 750, 1000, 2500, 5000, 10000,
                25000, 50000, 75000, 100000
            };

            var numberOfAmounts = briefCaseDollarAmounts.Count;
            for (var id = 1; id < 19; id++)
            {
                this.createRandomizedBriefcaseAndAddItToCollection(briefCaseDollarAmounts, numberOfAmounts, id);
                numberOfAmounts--;
            }
        }

        private void createRandomizedBriefcaseAndAddItToCollection(List<int> briefCaseDollarAmounts,
            int numberOfAmounts, int id)
        {
            var rand = new Random();
            var dollarAmount = briefCaseDollarAmounts[rand.Next(0, numberOfAmounts)];
            var briefCase = new BriefCase(id, dollarAmount);
            this.BriefCases.Add(briefCase);
            briefCaseDollarAmounts.Remove(dollarAmount);
        }

        private void createRegularRoundBriefCases()
        {
            var briefCaseDollarAmounts = new List<int> {
                0, 1, 5, 10, 25, 50, 75, 100, 200, 300, 400, 500, 750, 1000, 5000, 10000, 25000,
                50000, 75000, 100000, 200000, 300000, 400000, 500000, 750000, 1000000
            };

            var numberOfAmounts = briefCaseDollarAmounts.Count;
            for (var id = 1; id < 27; id++)
            {
                this.createRandomizedBriefcaseAndAddItToCollection(briefCaseDollarAmounts, numberOfAmounts, id);
                numberOfAmounts--;
            }
        }

        private void createSyndicatedRoundBriefCases()
        {
            var briefCaseDollarAmounts = new List<int> {
                0, 1, 5, 10, 25, 50, 75, 100, 200, 300, 400, 500, 750, 1000, 2500, 5000, 10000, 25000,
                50000, 75000, 100000, 150000, 200000, 250000, 350000, 500000
            };

            var numberOfAmounts = briefCaseDollarAmounts.Count;
            for (var id = 1; id < 27; id++)
            {
                this.createRandomizedBriefcaseAndAddItToCollection(briefCaseDollarAmounts, numberOfAmounts, id);
                numberOfAmounts--;
            }
        }

        /// <summary>
        ///     Creates the dollar amounts(Winnings) list
        /// </summary>
        /// <param name="dollarRange">The dollar range.</param>
        /// <returns> The list of Dollar amounts(Possible winnings)</returns>
        public IList<int> CreateDollarAmounts(DollarAmount dollarRange)
        {
            if (dollarRange.Equals(DollarAmount.Quickplay))
            {
                this.DollarAmounts = new List<int> {
                    0, 5, 10, 25, 50, 75, 100, 250, 500, 750, 1000, 2500, 5000, 10000,
                    25000, 50000, 75000, 100000
                };
            }
            else if (dollarRange.Equals(DollarAmount.Regular))
            {
                this.DollarAmounts = new List<int> {
                    0, 1, 5, 10, 25, 50, 75, 100, 200, 300, 400, 500, 750, 1000, 5000, 10000, 25000,
                    50000, 75000, 100000, 200000, 300000, 400000, 500000, 750000, 1000000
                };
            }
            else if (dollarRange.Equals(DollarAmount.Syndicated))
            {
                this.DollarAmounts = new List<int> {
                    0, 1, 5, 10, 25, 50, 75, 100, 200, 300, 400, 500, 750, 1000, 2500, 5000, 10000, 25000,
                    50000, 75000, 100000, 150000, 200000, 250000, 350000, 500000
                };
            }

            return this.DollarAmounts;
        }

        #endregion
    }
}