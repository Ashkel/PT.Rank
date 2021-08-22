using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT.Rank
{
	public class RankLevel
	{
		private string _fileName = "";

		public string Id { get; private set; }
		public string Name { get; private set; }
		public int Level { get; private set; }
		public int Exp { get; private set; }

		public RankLevel(string fileName)
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
					reader.BaseStream.Seek(0x10, SeekOrigin.Begin);

					Name = Byte2String(reader.ReadBytes(32));

					reader.BaseStream.Seek(0xC8, SeekOrigin.Begin);

					Level = reader.ReadInt32();

					reader.BaseStream.Seek(0x2C0, SeekOrigin.Begin);

					Id = Byte2String(reader.ReadBytes(32));


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
				sb.Append(b);
			}

			return sb.ToString();
		}
	}
}
