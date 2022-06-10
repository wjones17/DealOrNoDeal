namespace DealOrNoDeal.Model
{
    /// <summary>
    ///     Creates an enum for different ranges of dollar amounts(Winnings)
    /// </summary>
    public enum DollarAmount
    {
        /// <summary>
        ///     Regular is used for seven and Ten Round Play, winnings go up to 1,000,000 dollars
        /// </summary>
        Regular,

        /// <summary>
        ///     Syndicated is used for seven and Ten Round Play, winnings go up to 500,000 dollars
        /// </summary>
        Syndicated,

        /// <summary>
        ///     Quickplay is used for Quickplay Round Play, winnings go up to 100,000 dollars
        /// </summary>
        Quickplay
    }
}