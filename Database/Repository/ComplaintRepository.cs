using Azure;
using CallCenterCoreAPI.Models;
using CallCenterCoreAPI.Models.QueryModel;
using Microsoft.Extensions.Logging;
using System.Data;
using System.Data.SqlClient;
using System.Net;

namespace CallCenterCoreAPI.Database.Repository
{
    public class ComplaintRepository
    {
        private readonly ILogger<ComplaintRepository> _logger;
        private string conn = AppSettingsHelper.Setting(Key: "ConnectionStrings:DevConn");

        private string MGVCLApiURL = AppSettingsHelper.Setting(Key: "MGVCL_API:ApiURL");
        private string MGVCLsecret_key = AppSettingsHelper.Setting(Key: "MGVCL_API:secret_key");
        private string MGVCLtoken = AppSettingsHelper.Setting(Key: "MGVCL_API:token");
        public ComplaintRepository(ILogger<ComplaintRepository> logger)
        {
            _logger = logger;
        }

        

    }
}
