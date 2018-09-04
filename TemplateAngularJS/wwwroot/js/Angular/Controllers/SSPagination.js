app.controller('PagerController', ['$scope', '$localStorage', '$http', function ($scope, $localStorage, $http) {

    var config = {
        headers: {
            'Contet-Type': 'application/json;charset=UTF-8'
        }
    }
   
    $scope.totalRecords = 0;
    $scope.totalPages = 0;
    $scope.recordsFiltered=0;
    $scope.pageIndex = 0;
    $scope.pageSize = 12;

    $scope.firstPage = function () {
        $scope.pageIndex = 0;
    };

    $scope.prevPage = function () {
        if ($scope.pageIndex - 1 >= 0) {
            $scope.pageIndex--;
        }
    };

    $scope.netxPage = function () {
        if ($scope.pageIndex + 1 < $scope.totalPages) {
            $scope.pageIndex++;
        }
    };

    $scope.lastPage = function () {
        $scope.pageIndex = $cope.totalPages;
    };



    $scope.init = function (urlGet) {
        $scope.urlGet = urlGet;
        $http.post(urlGet, {}, config).then(
            function (response) {
                $scope.data = response.data;
               
            },
            function (response) {
                swal('Error', 'error', 'error');
            }
        );
    }; //end init function




}]);
