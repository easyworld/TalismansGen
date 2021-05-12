using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalismansGen
{
    class GameDatasource
    {
        static Dictionary<string, HoleConfig> holeConfigMap = null;
        static Dictionary<int, SkillRule> skillRuleMap = null;

        public static List<KeyValuePair<string, int>> GetItems()
        {
            var list = GetSkillRuleMap().Values;
            List<KeyValuePair<string, int>> result = new List<KeyValuePair<string, int>>();
            foreach (SkillRule rule in list)
            {
                result.Add(new KeyValuePair<string, int>(rule.name, rule.id));
            }
            return result;
        }

        public static Dictionary<string, HoleConfig> GetHoleMap()
        {
            if (holeConfigMap != null)
            {
                return holeConfigMap;
            } else
            {
                holeConfigMap = new Dictionary<string, HoleConfig>();
                var strings = TalismansGen.Properties.Resources.levelHoleMap.Split('\n');
                for (int i = 0; i < strings.Length; i++)
                {
                    var hole = new HoleConfig(strings[i]);
                    holeConfigMap.Add(hole.key, hole);
                }
            }
           
            return holeConfigMap;
        }

        public static Dictionary<int, SkillRule> GetSkillRuleMap()
        {
            if (skillRuleMap != null) return skillRuleMap;
            skillRuleMap = new Dictionary<int, SkillRule>();
            var strings = TalismansGen.Properties.Resources.skill.Split('\n');
            for (int i = 0; i < strings.Length; i++)
            {
                SkillRule rule = new SkillRule(strings[i]);
                skillRuleMap.Add(rule.id, rule);
            }
            return skillRuleMap;
        }
    }
}
