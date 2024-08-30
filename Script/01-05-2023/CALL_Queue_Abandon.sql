CREATE TABLE CALL_Queue_Abandon
(Date1 Date,
Total_Calls_Offered BIGINT,
Total_Calls_Answered BIGINT,
Short_Calls	BIGINT,
Ans_LessThan_5_Secs BIGINT,
Ans_6to10_Secs	BIGINT,
Ans_11to20_Secs	BIGINT,
Ans_21to30_Secs	BIGINT,
Ans_31to40_Secs	BIGINT,
Ans_41to50_Secs	BIGINT,
Ans_51to60_Secs	BIGINT,
Ans_GreaterThan_60_Secs	BIGINT,
Total_Calls_Abandon	BIGINT,
Aban_LessThan5_Sec	BIGINT,
Aban_6to10_Secs	BIGINT,
Aban_11to20_Secs BIGINT,
Aban_21to30_Secs BIGINT,
Aban_31to40_Secs BIGINT,
Aban_41to50_Secs BIGINT,
Aban_51to60_Secs BIGINT,
Aban_GreaterThan_60_Secs BIGINT,
Failed BIGINT,
Total_Call_Handling_Time NVARCHAR(50),
Total_Talk_Time	NVARCHAR(50),
Average_Talk_Time NVARCHAR(50),
Average_Call_Handling_Time NVARCHAR(50),
Calls_Held	BIGINT,
Calls_Queued BIGINT,
Calls_Queue_Time NVARCHAR(50),
Avg_Queue_Time NVARCHAR(50),
Service_per	DECIMAL(18,2),
Aban_Per DECIMAL(18,2),
SLA_Per DECIMAL(18,2),
ABN_10_Sec BIGINT,
ABN_10_Sec_Per DECIMAL(18,2),
ABN_20_Sec	BIGINT,
ABN_20_Sec_Per	DECIMAL(18,2),
ABN_30_Sec	BIGINT,
ABN_30_Sec_Per	DECIMAL(18,2),
ABN_60_Sec	BIGINT,
ABN_60_Sec_Per	DECIMAL(18,2),
ABN_90_Sec	BIGINT,
ABN_90_Sec_Per	DECIMAL(18,2),
SLA_10_Sec	BIGINT,
SLA_10_Sec_Per	DECIMAL(18,2),
SLA_20_Sec	BIGINT,
SLA_20_Sec_Per	DECIMAL(18,2),
SLA_30_Sec	BIGINT,
SLA_30_Sec_Per	DECIMAL(18,2),
SLA_60_Sec	BIGINT,
SLA_60_Sec_Per	DECIMAL(18,2),
SLA_90_Sec	BIGINT,
SLA_90_Sec_Per DECIMAL(18,2),
Total_Hold_Time NVARCHAR(50),
Avg_Hold_Time_of_Ans NVARCHAR(50),
Total_Wrapup_Time NVARCHAR(50),
Avg_Wrapup_Time NVARCHAR(50),
Is_Active BIT,
Is_Deleted BIT,
Time_Stamp DATETIME)