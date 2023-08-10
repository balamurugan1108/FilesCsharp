using DataLayer;

namespace BusinessLogicLayer
{
    public class LogicLayer : ILogicLayer
    {
        private readonly IDataLayerCls _dataLayerCls;
        public LogicLayer(IDataLayerCls dataLayerCls)
        {
            _dataLayerCls = dataLayerCls;
        }
        public object GetJson()
        {
            var data = _dataLayerCls.GetDataLayer();
            return data;
        }
    }
}