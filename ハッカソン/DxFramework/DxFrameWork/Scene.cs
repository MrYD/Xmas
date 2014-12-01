using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DxFramework
{
   abstract class Scene
    {
        public Scene NextScene { get;set; }
        SortedDictionary<int, List<DrawableBase>> DrawableList;
        public Scene()
        {
            DrawableList = new SortedDictionary<int, List<DrawableBase>>();//init,update,startscene(未実装),draw
        }
        public void wholeInit()
        {
            preInit();
            init();
            postInit();
        }
        public abstract void init();
        public void preInit() 
        {
            setAutoRemoveFunc();
            setAutoAddFunc(); //ここでリストをセット！
            DrawableList.Clear(); 
            NextScene = this; 
        }
        public void postInit() {}
        public void wholeUpdate()
        {
            preUpdate();
            update();
            postUpdate();
        }
        public void preUpdate()
        {
            NextScene = this;
            setAutoRemoveFunc();
            setAutoAddFunc();//ここでリストをセット！
           
        }
        public void postUpdate()
        {
            foreach (KeyValuePair<int, List<DrawableBase>> l in DrawableList.ToArray())
            {
                for (int i = 0; i < l.Value.Count();i++ )
                {
                    if (l.Value[i].isVisible) l.Value[i].update();
                }
               
            }
        }
        public abstract void update();
        void setAutoAddFunc()
        {
            DrawableBase.setAutoAddFunc(addChild);
        }
        void setAutoRemoveFunc()
        {
            DrawableBase.setAutoRemoveFunc(removeChild);
        }
        public void draw()
        {
            foreach (KeyValuePair<int, List<DrawableBase>> l in DrawableList.ToArray())
            {
                foreach(DrawableBase i in l.Value)
                {
                    if(i.isVisible)i.draw();
                }
            }
        }
        public void addChild(DrawableBase obj)
        {
            if (DrawableList.ContainsKey(obj.layer) == false) { DrawableList.Add(obj.layer, new List<DrawableBase>()); }
            DrawableList[obj.layer].Add(obj);
        }
        public void removeChild(DrawableBase obj)
        {
                DrawableList[obj.layer].Remove(obj);
        }
    }
}
//TODO
/*afterdrawいらない
 *ボタンのデフォルトバージョンみたいなのは、staticでmakeDefaultButtonみたいな感じで作る
 *init,update,startscene(未実装),draw
 *上記のうち、draw以外はちゃんとbaseを呼ぶ（setautoaddlist関係)
 *もしくは、setautoaddlistはスタック状にする？
 *そして明示的に読んだ方がいい？
 * */