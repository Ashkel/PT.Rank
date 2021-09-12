using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace PT.Rank
{
	public class RankEntry
	{
		private string _fileName = "";

		public string Id { get; private set; }
		public string Name { get; private set; }
		public int Job { get; private set; }
		public int Level { get; private set; }
		public int Exp { get; private set; }

		public RankEntry(string fileName)
		{
			_fileName = fileName;

			if(File.Exists(_fileName))
			{
				GetData();
			}
		}

		private void GetData()
		{
			try
			{
				using(var fs = File.OpenRead(_fileName))
				using(var reader = new BinaryReader(fs))
				{
					// go to Name offset and get it.
					reader.BaseStream.Seek(0x10, SeekOrigin.Begin);

					Name = Byte2String(reader.ReadBytes(32));

					// go to Job offset and get it.
					reader.BaseStream.Seek(0xC4, SeekOrigin.Begin);

					Job = reader.ReadInt32();

					// go to Level offset and get it.
					reader.BaseStream.Seek(0xC8, SeekOrigin.Begin);

					Level = reader.ReadInt32();

					// go to Exp offset and get it.
					reader.BaseStream.Seek(0x138, SeekOrigin.Begin);

					long xpLow = reader.ReadInt32();

					// go to Next_Exp offset and get it.
					reader.BaseStream.Seek(0x13C, SeekOrigin.Begin);

					long nextXpLow = reader.ReadInt32();

					reader.BaseStream.Seek(0x180, SeekOrigin.Begin);

					// go to Exp_High offset and get it.
					long xpHigh = reader.ReadInt32();

					// go to Account Id offset and get it.
					reader.BaseStream.Seek(0x2C0, SeekOrigin.Begin);

					Id = Byte2String(reader.ReadBytes(32));

					// calculate xp percentage
					long nowExp = (xpHigh << 32) | (xpLow & 0xFFFFFFFF);
					long nextExp = (xpHigh << 32) | (nextXpLow & 0xFFFFFFFF);
					
					Exp = Math.Abs((int)(nextExp - nowExp));
				}
			}
			catch(Exception)
			{
				throw;
			}
		}

		private string Byte2String(byte[] buffer)
		{
			var sb = new StringBuilder();

			foreach(var b in buffer)
			{
				char c = (char)b;

				if(char.IsLetterOrDigit(c))
				{
					sb.Append(c);
				}
			}

			return sb.ToString();
		}

		private int GetPercent(long value, long whole)
		{
			return (int)((value * 100) / whole);
		}

		public override string ToString()
		{
			return $"Id: {Id}, Name: {Name}, Job: {Job}, Level: {Level}, Exp: {Exp}";
		}
	}
}
