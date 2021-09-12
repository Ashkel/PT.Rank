using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PT.Rank.Helper
{
	using Engine;

	public static class Utils
	{
		#region Helper methods

		public static string GetWord(string line, ref int position)
		{
			var buffer = new StringBuilder();

			if(line != string.Empty)
			{
				while((position < line.Length) &&
					((line[position] == 32) ||
					(line[position] == 9)))
				{
					if((line[position] == '\r') ||
						(line[position] == '\n') ||
						(line[position] == 0))
					{
						break;
					}

					++position;
				}

				while((position < line.Length) &&
					((line[position] != 32) &&
					(line[position] != 9)))
				{
					if((line[position] == '\r') ||
						(line[position] == '\n') ||
						(line[position] == 0))
					{
						break;
					}

					buffer.Append(line[position]);

					++position;
				}
			}

			return buffer.ToString();
		}

		public static string GetString(string line, ref int position)
		{
			var buffer = new StringBuilder();

			if(line != string.Empty)
			{
				while((position < line.Length) &&
						(line[position] != 34))
				{
					if((line[position] == '\r') ||
						(line[position] == '\n') ||
						(line[position] == 0))
					{
						break;
					}

					++position;
				}

				++position;

				while((position < line.Length) &&
						(line[position] != 34))
				{
					if((line[position] == '\r') ||
						(line[position] == '\n') ||
						(line[position] == 0))
					{
						break;
					}

					buffer.Append(line[position]);

					++position;
				}
			}

			return buffer.ToString();
		}

		public static string FormatErrorMessage(Exception exception, string fileName, int line, string text)
		{
			var sb = new StringBuilder();

			sb.AppendLine($"Exception: {exception.GetType()}");

			sb.AppendLine("{");
			sb.AppendLine($"\tFile: \"{fileName}\",");
			sb.AppendLine($"\tLine: \"{line}\",");

			if(!string.IsNullOrEmpty(text))
			{
				sb.AppendLine($"\tAt: \"{text}\",");
			}

			sb.AppendLine($"\tMessage: \"{exception.Message}\"");
			sb.AppendLine("}");
			sb.AppendLine();

			return sb.ToString();
		}

		public static string EncodeString(string s, Encoding srcEncoding, Encoding dstEncoding)
		{
			var src = srcEncoding.GetBytes(s);
			var bytes = Encoding.Convert(srcEncoding, dstEncoding, src);

			char[] chars = new char[dstEncoding.GetCharCount(bytes, 0, bytes.Length)];

			dstEncoding.GetChars(bytes, 0, bytes.Length, chars, 0);

			return new string(chars);
		}

		public static string ComputeMD5(string file)
		{
			MD5 md5 = MD5.Create();

			string hash = "";

			using(var stream = File.OpenRead(file))
			{
				hash = BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", "");
			}

			return hash;
		}

		public static string ParseString(string buffer, ref int position)
		{
			if(GetWord(buffer, ref position)[0] == 34)
			{
				return GetString(buffer, ref position);
			}

			return string.Empty;
		}

		public static int ParseInteger(string buffer, ref int position)
		{
			var str = GetWord(buffer, ref position);

			if(!string.IsNullOrEmpty(str))
			{
#if !DEBUG
				// fix "*ºí·°À²	 5%"
				if(str.EndsWith("%"))
				{
					str = str.Remove(str.Length - 1);
				}
#endif
				if(int.TryParse(str, out int result))
				{
					return result;
				}
			}

			return 0;
		}

		public static float ParseFloat(string buffer, ref int position)
		{
			var str = GetWord(buffer, ref position);

			if(!string.IsNullOrEmpty(str) &&
				float.TryParse(str, out float result))
			{
				return result;
			}

			return 0;
		}

		public static bool ParseBool(string buffer, ref int position, string condition = null)
		{
			if(!string.IsNullOrEmpty(condition))
			{
				var str = GetWord(buffer, ref position);

				if(string.Compare(str, condition) != 0)
				{
					return false;
				}
			}

			return true;
		}

		public static Range ParseRange(string buffer, ref int position)
		{
			int min = ParseInteger(buffer, ref position);

			int val = ParseInteger(buffer, ref position);

			return new Range(Math.Min(min, val), Math.Max(min, val));
		}

		public static RangeF ParseRangeF(string buffer, ref int position)
		{
			float min = ParseFloat(buffer, ref position);

			float val = ParseFloat(buffer, ref position);

			return new RangeF(Math.Min(min, val), Math.Max(min, val));
		}

		public static Loot? ParseLoot(string buffer, ref int position)
		{
			int temp = position;

			var str = GetWord(buffer, ref temp);

			if(str.CompareTo("Ä«¿îÅÍ") == 0)
			{
				return null;
			}

			temp = position;

			int rate = ParseInteger(buffer, ref temp);

			str = GetWord(buffer, ref temp);

			if(str.CompareTo("¾øÀ½") == 0)
			{
				return new Loot()
				{
					Rate = rate,
					Money = null,
					Coins = null,
					Items = null
				};
			}
			else if(str.CompareTo("µ·") == 0)
			{
				var money = ParseRange(buffer, ref temp);

				return new Loot()
				{
					Rate = rate,
					Money = money,
					Coins = null,
					Items = null
				};
			}
			else if(str.CompareTo("coins") == 0)
			{
				var coins = ParseRange(buffer, ref temp);

				return new Loot()
				{
					Rate = rate,
					Money = null,
					Coins = coins,
					Items = null
				};
			}
			else
			{
				var items = new List<string>();

				while(!string.IsNullOrEmpty(str))
				{
					items.Add(str);

					str = GetWord(buffer, ref temp);
				}

				return new Loot()
				{
					Rate = rate,
					Money = null,
					Coins = null,
					Items = items
				};
			}
		}

		#endregion
	}
}
