' NOTE: You can use the "Rename" command on the context menu to change the interface name "IService1" in both code and config file together.
<ServiceContract()>
Public Interface IService1

    <OperationContract()>
    Function Reserve(ByVal seatType As String, ByVal classType As String) As Boolean



End Interface

