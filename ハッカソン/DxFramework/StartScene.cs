using DxLibDLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DxFramework
{
    class StartScene : Scene
    {

        public StartScene()
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
        public static StartScene instance { get; set; }
    }
}
