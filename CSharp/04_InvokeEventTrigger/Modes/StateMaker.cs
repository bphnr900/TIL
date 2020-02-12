using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace GetPartsStructures.Models
{
    class StateMaker
    {
        public ObservableCollection<State> GetStates()
        {
            var list = new ObservableCollection<State>();
            //近畿を追加
            var kinki = "近畿";
            list.Add(new State { AreaID = 1, Area = kinki, PrefectureID = 2, Prefecture = "大阪" });
            list.Add(new State { AreaID = 1, Area = kinki, PrefectureID = 1, Prefecture = "兵庫" });
            list.Add(new State { AreaID = 1, Area = kinki, PrefectureID = 7, Prefecture = "奈良" });
            list.Add(new State { AreaID = 1, Area = kinki, PrefectureID = 3, Prefecture = "京都" });
            list.Add(new State { AreaID = 1, Area = kinki, PrefectureID = 4, Prefecture = "滋賀" });
            list.Add(new State { AreaID = 1, Area = kinki, PrefectureID = 5, Prefecture = "三重" });
            list.Add(new State { AreaID = 1, Area = kinki, PrefectureID = 6, Prefecture = "和歌山" });

            //四国を追加
            var shikoku = "四国";
            list.Add(new State { AreaID = 2, Area = shikoku, PrefectureID = 8, Prefecture = "徳島" });
            list.Add(new State { AreaID = 2, Area = shikoku, PrefectureID = 10, Prefecture = "高知" });
            list.Add(new State { AreaID = 2, Area = shikoku, PrefectureID = 11, Prefecture = "愛媛" });
            list.Add(new State { AreaID = 2, Area = shikoku, PrefectureID = 9, Prefecture = "香川" });

            return list;
        }


        public StateMaker()
        {
        }
    }
}
