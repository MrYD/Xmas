using DxLibDLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DxFramework
{
    class GameScene : Scene
    {

        public GameScene()
            : base()
        {
            init();
            instance = this;
        }
        public override void init()
        {
          
        }
        public override void update()
        {
            base.update();
        
        }
        public static GameScene instance { get; set; }
    }
}
