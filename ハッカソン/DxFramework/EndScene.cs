using DxLibDLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DxFramework
{
    class EndScene : Scene
    {

        public EndScene()
            : base()
        {
            init();
            instance = this;
        }
        public override void init()
        {
            var back = new Graphic();
            back.GraphName = "resource/img/GameEnd.png";
        }
        public override void update()
        {
            base.update();
        }
        public static EndScene instance { get; set; }
    }
}
