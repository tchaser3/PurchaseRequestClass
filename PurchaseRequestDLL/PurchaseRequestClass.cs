/* Name:            Purchase Request Class
 * Date:            1-8-20
 * Author:          Terry Holmes
 * 
 * Description:     This class is used for the header of purchase requests */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewEventLogDLL;

namespace PurchaseRequestDLL
{
    public class PurchaseRequestClass
    {
        EventLogClass TheEventLogClass = new EventLogClass();

        PurchaseRequestDataSet aPurchaseRequestDataSet;
        PurchaseRequestDataSetTableAdapters.purchaserequestTableAdapter aPurchaseRequestTableAdapter;

        InsertPurchaseRequestEntryTableAdapters.QueriesTableAdapter aInsertPruchaseRequestTableAdapter;

        UpdatePurchaseRequestBooleanEntryTableAdapters.QueriesTableAdapter aUpdatePurchaseRequestBooleanTableAdapter;

        UpdatePurchaseRequestApprovalEntryTableAdapters.QueriesTableAdapter aUpdatePurchaseRequestApprovalTableAdapter;

        UpdatePurchaseRequestDenialEntryTableAdapters.QueriesTableAdapter aUpdatePurchaseRequestDenialTableAdapter;

        UpdatePurchaseRequestCompleteDateEntryTableAdapters.QueriesTableAdapter aUpdatePurchaseRequestCompleteDateTableAdapter;

        UpdatePurchaseRequestStatusEntryTableAdapters.QueriesTableAdapter aUpdatePurchaseRequestStatusTableAdapter;

        UpdatePurchaseRequestNotesEntryTableAdapters.QueriesTableAdapter aUpdatePurchaseRequestNotesTableAdapter;

        FindPurchaseRequestByPONumberDataSet aFindPurchaseRequestByPONumberDataSet;
        FindPurchaseRequestByPONumberDataSetTableAdapters.FindPurchaseRequestByPONumberTableAdapter aFindPurchaseRequestByPONumberTableAdapter;

        FindPurchaseRequestByStatusDataSet aFindPurchaseRequestByStatusDataSet;
        FindPurchaseRequestByStatusDataSetTableAdapters.FindPurchaseRequestByStatusTableAdapter aFindPurchaseRequestByStatusTableAdapter;

        FindPurchaseRequestByRequestDateDataSet aFindPurchaseRequestByRequestDateDataSet;
        FindPurchaseRequestByRequestDateDataSetTableAdapters.FindPurchaseRequestByRequestDateTableAdapter aFindPurchaseRequestByRequestDateTableAdapter;

        public FindPurchaseRequestByRequestDateDataSet FindPurchaseRequestByRequestDate(DateTime datRequestDate)
        {
            try
            {
                aFindPurchaseRequestByRequestDateDataSet = new FindPurchaseRequestByRequestDateDataSet();
                aFindPurchaseRequestByRequestDateTableAdapter = new FindPurchaseRequestByRequestDateDataSetTableAdapters.FindPurchaseRequestByRequestDateTableAdapter();
                aFindPurchaseRequestByRequestDateTableAdapter.Fill(aFindPurchaseRequestByRequestDateDataSet.FindPurchaseRequestByRequestDate, datRequestDate);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Purchase Request Class // Find Purchase Request By Request Date " + Ex.Message);
            }

            return aFindPurchaseRequestByRequestDateDataSet;
        }
        public FindPurchaseRequestByStatusDataSet FindPurchaseRequestByStatus(string strStatus)
        {
            try
            {
                aFindPurchaseRequestByStatusDataSet = new FindPurchaseRequestByStatusDataSet();
                aFindPurchaseRequestByStatusTableAdapter = new FindPurchaseRequestByStatusDataSetTableAdapters.FindPurchaseRequestByStatusTableAdapter();
                aFindPurchaseRequestByStatusTableAdapter.Fill(aFindPurchaseRequestByStatusDataSet.FindPurchaseRequestByStatus, strStatus);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Purchase Request Class // Find Purchase Request By Class " + Ex.Message);
            }

            return aFindPurchaseRequestByStatusDataSet;
        }
        public FindPurchaseRequestByPONumberDataSet FindPurchaseRequestByPONumber(int intPONumber)
        {
            try
            {
                aFindPurchaseRequestByPONumberDataSet = new FindPurchaseRequestByPONumberDataSet();
                aFindPurchaseRequestByPONumberTableAdapter = new FindPurchaseRequestByPONumberDataSetTableAdapters.FindPurchaseRequestByPONumberTableAdapter();
                aFindPurchaseRequestByPONumberTableAdapter.Fill(aFindPurchaseRequestByPONumberDataSet.FindPurchaseRequestByPONumber, intPONumber);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Purchase Request Class // Find Purchase Request By PO Number " + Ex.Message);
            }

            return aFindPurchaseRequestByPONumberDataSet;
        }
        public bool UpdatePurchaseRequestNotes(int intPONumber, string strRequestNotes)
        {
            bool blnFatalError = false;

            try
            {
                aUpdatePurchaseRequestNotesTableAdapter = new UpdatePurchaseRequestNotesEntryTableAdapters.QueriesTableAdapter();
                aUpdatePurchaseRequestNotesTableAdapter.UpdatePurchaseRequestNotes(intPONumber, strRequestNotes);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Purchase Request Class // Update Purchase Request Notes " + Ex.Message);

                blnFatalError = true;
            }

            return blnFatalError;
        }
        public bool UpdatePurchaseRequestStatus(int intPONumber, string strCurrentStatus)
        {
            bool blnFatalError = false;

            try
            {
                aUpdatePurchaseRequestStatusTableAdapter = new UpdatePurchaseRequestStatusEntryTableAdapters.QueriesTableAdapter();
                aUpdatePurchaseRequestStatusTableAdapter.UpdatePurchaseRequestStatus(intPONumber, strCurrentStatus);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Purchase Request Class // Update Purchase Request Status " + Ex.Message);

                blnFatalError = true;
            }

            return blnFatalError;
        }
        public bool UpdatePurchaseRequestCompleteDate(int intPONumber, string strCurrentStatus)
        {
            bool blnFatalError = false;

            try
            {
                aUpdatePurchaseRequestCompleteDateTableAdapter = new UpdatePurchaseRequestCompleteDateEntryTableAdapters.QueriesTableAdapter();
                aUpdatePurchaseRequestCompleteDateTableAdapter.UpdatePurchaseRequestCompleteDate(intPONumber, strCurrentStatus, DateTime.Now);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Purchase Request Class // Update Purchase Request Complete Date " + Ex.Message);

                blnFatalError = true;
            }

            return blnFatalError;
        }
        public bool UpdatePurchaseRequestDenial(int intPONumber, bool blnRequestDenial, DateTime datDenialDate, string strDeinalNotes)
        {
            bool blnFatalError = false;

            try
            {
                aUpdatePurchaseRequestDenialTableAdapter = new UpdatePurchaseRequestDenialEntryTableAdapters.QueriesTableAdapter();
                aUpdatePurchaseRequestDenialTableAdapter.UpdatePurchaseRequestDenial(intPONumber, blnRequestDenial, datDenialDate, strDeinalNotes);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Purchase Request Class // Update Purchase Request Denial " + Ex.Message);

                blnFatalError = true;
            }

            return blnFatalError;
        }
        public bool UpdatePurchaseRequestApproval(int intPONumber, DateTime datApprovalDate, bool blnPurchaserApproval)
        {
            bool blnFatalError = false;

            try
            {
                aUpdatePurchaseRequestApprovalTableAdapter = new UpdatePurchaseRequestApprovalEntryTableAdapters.QueriesTableAdapter();
                aUpdatePurchaseRequestApprovalTableAdapter.UpdatePurchaseRequestApproval(intPONumber, datApprovalDate, blnPurchaserApproval);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Purchase Request Class // Udpate Purchase Request Approval " + Ex.Message);

                blnFatalError = true;
            }

            return blnFatalError;

        }
        public bool UpdatePurchaseRequestBoolean(int intPONumber, bool blnQuoteRequested, bool blnPurchaseRequest)
        {
            bool blnFatalError = false;

            try
            {
                aUpdatePurchaseRequestBooleanTableAdapter = new UpdatePurchaseRequestBooleanEntryTableAdapters.QueriesTableAdapter();
                aUpdatePurchaseRequestBooleanTableAdapter.UpdatePurhaseRequestBoolean(intPONumber, blnQuoteRequested, blnPurchaseRequest);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Purchase Request Class // Update Purchase Request Boolean " + Ex.Message);

                blnFatalError = true;
            }

            return blnFatalError;
        }
        public bool InsertPurchaseRequest(DateTime datRequestDate, DateTime datRequiredDate, int intRequestingEmployeeID, int intDepartmentHeadID, int intDepartmentID, int intOfficeID, int intVendorID, string strRequestNotes, bool blnQuoteRequested, bool blnPurchaseRequested, string strCurrentStatus)
        {
            bool blnFatalError = false;

            try
            {
                aInsertPruchaseRequestTableAdapter = new InsertPurchaseRequestEntryTableAdapters.QueriesTableAdapter();
                aInsertPruchaseRequestTableAdapter.InsertPurchaseRequest(datRequestDate, datRequestDate, intRequestingEmployeeID, intDepartmentHeadID, intDepartmentID, intOfficeID, intVendorID, strRequestNotes, blnQuoteRequested, blnPurchaseRequested, strCurrentStatus);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Purchase Request Class // Insert Purchase Request " + Ex.Message);

                blnFatalError = true;
            }

            return blnFatalError;
        }
        public PurchaseRequestDataSet GetPurchaseRequestInfo()
        {
            try
            {
                aPurchaseRequestDataSet = new PurchaseRequestDataSet();
                aPurchaseRequestTableAdapter = new PurchaseRequestDataSetTableAdapters.purchaserequestTableAdapter();
                aPurchaseRequestTableAdapter.Fill(aPurchaseRequestDataSet.purchaserequest);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Purchase Request Class // Get Purchase Request Info " + Ex.Message);
            }

            return aPurchaseRequestDataSet;
        }
        public void UpdatePurchaseRequestDB(PurchaseRequestDataSet aPurchaseRequestDataSet)
        {
            try
            {
                aPurchaseRequestTableAdapter = new PurchaseRequestDataSetTableAdapters.purchaserequestTableAdapter();
                aPurchaseRequestTableAdapter.Update(aPurchaseRequestDataSet.purchaserequest);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Purchase Request Class // Get Purchase Request Info " + Ex.Message);
            }
        }
    }
}
