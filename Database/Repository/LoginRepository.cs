using CallCenterCoreAPI.Database.Repository;
using Microsoft.AspNetCore.Mvc.Routing;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CallCenterCoreAPI.Models.QueryModel;
using CallCenterCoreAPI.Models.ViewModel;
using CallCenterCoreAPI.Controllers;
using Serilog;
using Microsoft.Extensions.Logging;
using CallCenterCoreAPI.Filters;
using CallCenterCoreAPI.Models;
using RestSharp;
using Newtonsoft.Json;
using System.DirectoryServices.Protocols;
using Microsoft.AspNetCore.Http;
using Microsoft.SqlServer.Server;
using System.Globalization;

namespace CallCenterCoreAPI.Database.Repository
{
    public class LoginRepository 
    {
   
        private readonly ILogger<LoginRepository> _logger;
        private string MGVCLApiURL = AppSettingsHelper.Setting(Key: "MGVCL_API:ApiURL");
        private string MGVCLsecret_key = AppSettingsHelper.Setting(Key: "MGVCL_API:secret_key");
        private string MGVCLtoken = AppSettingsHelper.Setting(Key: "MGVCL_API:token");
        private string MGVCLInfraApiURL = AppSettingsHelper.Setting(Key: "MGVCL_InfraAPI:ApiURL");
        private string MGVCLInfraAccessTokenURL = AppSettingsHelper.Setting(Key: "MGVCL_InfraAPI:GetTokenAPIURL");
        public LoginRepository(ILogger<LoginRepository> logger)
        {
            _logger = logger;
        }

        private string conn=AppSettingsHelper.Setting(Key: "ConnectionStrings:DevConn");


        public UserViewModel ValidateUser(UserRequestQueryModel user)
        {
            List<UserViewModel> userViewModel = new List<UserViewModel>();
            UserViewModel userViewModelReturn = new UserViewModel();  
            try
            {
                SqlParameter[] param ={new SqlParameter("@Username",user.LoginId.Trim()),new SqlParameter("@Password",Utility.EncryptText(user.Password.Trim()) )};
                DataSet dataSet = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "Validate_User_API_LOGIN", param);
                userViewModel = AppSettingsHelper.ToListof<UserViewModel>(dataSet.Tables[0]);
                userViewModelReturn = userViewModel[0];
                _logger.LogInformation(conn);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

            }
            return userViewModelReturn;
        }

        public UserViewAPIModel ValidateUserAPI(UserRequestQueryModel user)
        {
            List<UserViewAPIModel> userViewModel = new List<UserViewAPIModel>();
            UserViewAPIModel userViewModelReturn = new UserViewAPIModel();
            try
            {
                SqlParameter[] param = { new SqlParameter("@Username", user.LoginId.Trim()), new SqlParameter("@Password", Utility.EncryptText(user.Password.Trim())) };
                DataSet dataSet = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "Validate_User_API", param);
                userViewModel = AppSettingsHelper.ToListof<UserViewAPIModel>(dataSet.Tables[0]);
                userViewModelReturn = userViewModel[0];
                _logger.LogInformation(conn);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

            }
            return userViewModelReturn;
        }

        

        #region getAccessToken 
        /// <summary>
        /// Save Complaint
        /// </summary>
        /// <param name="complaintNo"></param>
        /// <returns></returns>
        public async Task<string> getAccessTokenAPI(ModelMgvcluser modelMgvcluser)
        {
            ModelMgvcluserResponse apiResponse = new ModelMgvcluserResponse();
            var client = new RestClient(MGVCLInfraAccessTokenURL);
            var restRequest = new RestRequest();
            restRequest.Method = Method.POST;
            restRequest.AddHeader("Accept", "application/json");
            restRequest.RequestFormat = DataFormat.Json;
            restRequest.AddJsonBody(modelMgvcluser);
            var response = await client.ExecuteAsync(restRequest);
            {
                apiResponse = JsonConvert.DeserializeObject<ModelMgvcluserResponse>(response.Content);
            }
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return apiResponse.data.jwt.ToString();
            }
            else
            {
                return apiResponse.data.jwt.ToString();
            }
        }
        #endregion
    }



}
