using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT.Rank.Engine
{
	public struct Loot
	{
		#region Field/Properties

		/// <summary>
		/// Drop rate of items
		/// </summary>
		public int Rate;

		/// <summary>
		/// Range between min-max gold
		/// </summary>
		public Range? Money;

		/// <summary>
		/// Range between min-max gold
		/// </summary>
		public Range? Coins;

		/// <summary>
		/// List of items
		/// </summary>
		public List<string> Items;

		public bool Nothing
		{
			get
			{
				return (this.Money == null) &&
						(this.Coins == null) &&
						(this.Items == null);
			}
		}

		#endregion


		#region Helper methods

		public override string ToString()
		{
			var sb = new StringBuilder();

			sb.Append(string.Format("Rate: {0}", this.Rate.ToString()));

			if(this.Money != null)
			{
				sb.Append(string.Format(", Money: [{0}]", this.Money.ToString()));
			}
			else if(this.Coins != null)
			{
				sb.Append(string.Format(", Coins: [{0}]", this.Coins.ToString()));
			}
			else if(this.Items != null)
			{
				var str = string.Join(", ", this.Items);

				sb.Append(string.Format(", Items: [{0}]", str));
			}
			else
			{
				sb.Append(", Items: Nothing");
			}

			return sb.ToString();
		}

		#endregion
	}
}
