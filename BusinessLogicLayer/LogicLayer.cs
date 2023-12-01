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
        public object JsonTOEXcel()
        {
            var data = _dataLayerCls.JsonTOEXcel();
            return data;
        }
        public object ExcelToJson()
        {
            var data =_dataLayerCls.ExcelToJson();
            return data;
        }
    }
}