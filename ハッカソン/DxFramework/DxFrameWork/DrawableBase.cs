using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxLibDLL;
namespace DxFramework
{
    abstract class DrawableBase
    {
        static Action<DrawableBase> autoAddFunc;
        static Action<DrawableBase> autoRemoveFunc;
        private int _layer;
        public int layer
        {
            get { return _layer; }
            set
            {
                if (layer == value) return;
                _layer = value;
                if (autoRemoveFunc != null) autoRemoveFunc(this);
                if (autoAddFunc != null) autoAddFunc(this);

            }
        }
        public bool isVisible { get; set; }
        public DrawableBase(int layer)
        {
            isVisible = true;
            this.layer = layer;
            if (autoAddFunc != null) autoAddFunc(this);
        }
        public static void setAutoAddFunc(Action<DrawableBase> addlistfunc) { autoAddFunc = addlistfunc; }
        public static void setAutoRemoveFunc(Action<DrawableBase> removelistfunc) { autoRemoveFunc = removelistfunc; }
        abstract public void draw();
        abstract public void update();
        public void delete()
        {
            if (autoRemoveFunc != null) autoRemoveFunc(this);
        }
    }
}
