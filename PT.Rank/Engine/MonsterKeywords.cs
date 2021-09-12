using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT.Rank.Engine
{
	public partial class Monster
	{
		public static class Keywords
		{
			public static readonly string KoreanName = "*ÀÌ¸§";

			public static readonly string EnglishName = "*Name";

			public static string[] DisplayName = new string[] { "*ÀÌ¸§", "*A_NAME", "*B_NAME", "*C_NAME", "*E_NAME", "*J_NAME", "*T_NAME", "*TH_NAME", "*V_NAME" };

			public static readonly string Model = "*¸ð¾çÆÄÀÏ";

			public static string[] Chat = new string[] { "*´ëÈ­", "*A_CHAT", "*B_CHAT", "*C_CHAT", "*E_CHAT", "*J_CHAT", "*T_CHAT", "*TH_CHAT", "*V_CHAT" };

			public static readonly string State = "*¼Ó¼º";

			public static readonly string SizeLevel = "*Å©±â";

			public static readonly string[] SoundCode = new string[] { "*¼Ò¸®­", "*È¿°úÀ½" };

			public static readonly string Level = "*·¹º§";

			public static readonly string IsBoss = "*µÎ¸ñ";

			public static readonly string MonsterClass = "*°è±Þ";

			public static readonly string Size = "*¸ðµ¨Å©±â";

			public static readonly string MoveSpeed = "*ÀÌµ¿·Â";

			public static readonly string AttackPower = "*°ø°Ý·Â";

			public static readonly string AttackSpeed = "*°ø°Ý¼Óµµ";

			public static readonly string ShootingRange = "*°ø°Ý¹üÀ§";

			public static readonly string AttackRating = "*¸íÁß·Â";

			public static readonly string Defence = "*¹æ¾î·Â";

			public static readonly string Absorption = "*Èí¼öÀ²";

			public static readonly string Block = "*ºí·°À²";

			public static string[] HP = new string[] { "*»ý¸í·Â", "*¶óÀÌÇÁ" };

			public static readonly string Organic = "*»ýÃ¼";
			public static readonly string Water = "*¹°";
			public static readonly string Lightning = "*¹ø°³";
			public static readonly string Ice = "*¾óÀ½";
			public static readonly string Wind = "*¹Ù¶÷";
			public static readonly string Earth = "*Áöµ¿·Â";
			public static readonly string Fire = "*ºÒ";
			public static readonly string Poison = "*µ¶";

			public static readonly string RealSight = "*½Ã¾ß";

			public static readonly string ArrowPosition = "*È­¸éº¸Á¤";

			public static readonly string ModelEvent = "*¿¹ºñ¸ðµ¨";

			public static readonly string SkillDamage = "*±â¼ú°ø°Ý·Â";
			public static readonly string SkillDistance = "*±â¼ú°ø°Ý°Å¸®";
			public static readonly string SkillRange = "*±â¼ú°ø°Ý¹üÀ§";
			public static readonly string SkillRating = "*±â¼ú°ø°Ý·ü";
			public static readonly string SkillCurse = "*ÀúÁÖ±â¼ú";

			// MovementType is in-game disabled, but keep it anyways
			public static readonly string MovementType = "*ÀÌµ¿Å¸ÀÔ";
			public static readonly string MoveRange = "*ÀÌµ¿¹üÀ§";

			public static readonly string ActiveHour = "*È°µ¿½Ã°£";

			public static readonly string GenerateGroup = "*Á¶Á÷";

			public static readonly string IQ = "*Áö´É";

			public static readonly string ClassCode = "*±¸º°ÄÚµå";

			public static string[] DamageStunPers = new string[] { "*½ºÅÏÀ²", "*½ºÅÏ·ü" };

			public static readonly string MonsterNature = "*Ç°¼º";

			public static readonly string EventCode = "*ÀÌº¥Æ®ÄÚµå";
			public static readonly string EventInfo = "*ÀÌº¥Æ®Á¤º¸";
			public static readonly string EventItem = "*ÀÌº¥Æ®¾ÆÀÌÅÛ";

			public static readonly string SpAttackPercetage = "*Æ¯¼ö°ø°Ý·ü";

			public static readonly string IsUndead = "*¾ðµ¥µå";

			public static readonly string MonsterType = "*¸ó½ºÅÍÁ¾Á·";

			public static readonly string Experience = "*°æÇèÄ¡";

			public static readonly string PotionCount = "*¹°¾àº¸À¯¼ö";
			public static readonly string PotionPercent = "*¹°¾àº¸À¯·ü";

			public static readonly string AllSeeItem = "*¾ÆÀÌÅÛ¸ðµÎ";
			public static readonly string FallItemMax = "*¾ÆÀÌÅÛÄ«¿îÅÍ";

			// Item craft(ores, recipes)
			public static readonly string FallItemsPlus = "*Ãß°¡¾ÆÀÌÅÛ";
			public static readonly string FallItems = "*¾ÆÀÌÅÛ";

			public static readonly string ZhoonFile = "*¿¬°áÆÄÀÏ";
		}
	}
}
