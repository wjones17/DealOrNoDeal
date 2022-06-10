using System.Collections.Generic;

namespace DealOrNoDeal.Model
{
    /// <summary>
    ///     Manages the creation of the rounds and the amount of cases to open per each round
    /// </summary>
    public class RoundManager
    {
        #region Methods

        /// <summary>
        ///     Creates the rounds based off of the enum given.
        /// </summary>
        /// <param name="rounds">The rounds.</param>
        /// <returns> The list of rounds created with the given enum information</returns>
        public IList<Round> CreateRounds(NumberOfRounds rounds)
        {
            IList<Round> gameRounds = new List<Round>();
            if (rounds.Equals(NumberOfRounds.Quickplay))
            {
                this.createQuickplayRoundSet(gameRounds);
            }
            else if (rounds.Equals(NumberOfRounds.Seven))
            {
                this.createSevenRoundSet(gameRounds);
            }
            else if (rounds.Equals(NumberOfRounds.Ten))
            {
                this.createTenRoundSet(gameRounds);
            }

            return gameRounds;
        }

        private void createTenRoundSet(IList<Round> gameRounds)
        {
            gameRounds.Add(new Round(1, 6));
            gameRounds.Add(new Round(2, 5));
            gameRounds.Add(new Round(3, 4));
            gameRounds.Add(new Round(4, 3));
            gameRounds.Add(new Round(5, 2));
            gameRounds.Add(new Round(6, 1));
            gameRounds.Add(new Round(7, 1));
            gameRounds.Add(new Round(8, 1));
            gameRounds.Add(new Round(9, 1));
            gameRounds.Add(new Round(10, 1));
        }

        private void createSevenRoundSet(IList<Round> gameRounds)
        {
            gameRounds.Add(new Round(1, 8));
            gameRounds.Add(new Round(2, 6));
            gameRounds.Add(new Round(3, 4));
            gameRounds.Add(new Round(4, 3));
            gameRounds.Add(new Round(5, 2));
            gameRounds.Add(new Round(6, 1));
            gameRounds.Add(new Round(7, 1));
        }

        private void createQuickplayRoundSet(IList<Round> gameRounds)
        {
            gameRounds.Add(new Round(1, 6));
            gameRounds.Add(new Round(2, 5));
            gameRounds.Add(new Round(3, 3));
            gameRounds.Add(new Round(4, 2));
            gameRounds.Add(new Round(5, 1));
        }

        #endregion
    }
}