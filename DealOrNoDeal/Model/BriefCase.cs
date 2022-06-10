using System;

namespace DealOrNoDeal.Model
{
    /// <summary>
    ///     <br>Creates a Briefcase object that will have an Id and a DollarAmount stored in it</br>
    /// </summary>
    public class BriefCase
    {
        #region Properties

        /// <summary>
        ///     The Id of the created briefcase
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     The DollarAmount stored in the created briefcase
        /// </summary>
        public int DollarAmount { get; set; }

        #endregion

        #region Constructors

        /// <summary>Initializes a new instance of the <see cref="BriefCase" /> class.</summary>
        /// Precondition : id >= 1 && dollarAmount >= 0
        /// Post-condition : this.Id == id && this.DollarAmount == dollarAmount
        /// <param name="id">The identifier.</param>
        /// <param name="dollarAmount">The value.</param>
        public BriefCase(int id, int dollarAmount)
        {
            if (id < 1)
            {
                throw new ArgumentException("id must be >= 1");
            }

            if (dollarAmount < 0)
            {
                throw new ArgumentException("dollarAmount must be >= 0");
            }

            this.Id = id;
            this.DollarAmount = dollarAmount;
        }

        #endregion
    }
}