app.controller('ContactController', ['$scope', '$localStorage', '$http', 'NgTableParams', function ($scope, $localStorage, $http, NgTableParams) {
    var config = {
        headers: {
            'Contet-Type': 'application/json;charset=UTF-8'
        }
    }

    $scope.init = function (urlGet) {
        var self = this;
        $scope.data = [];
        $scope.urlGet = urlGet;
        $http.post(urlGet, {}, config).then(
            function (response) {
                $scope.data = response.data;
                $scope.tableParams = new NgTableParams({ page: 1, count: 8 }, { data: $scope.data, counts: [5, 8, 10, 25, 50,], defaultSort: 'desc' });
            },
            function (response) {
                swal('Error', 'error', 'error');
            }
        );
    }; //end init function

    $scope.addContact = function (urlAdd) {
        $scope.contact =
            {
                'name': $scope.name,
                'phone': $scope.phone,
                'email': $scope.email,
            };
        $http.post(urlAdd, $scope.contact, config).then(
            function (response) {
                $scope.data.push(response.data);
                $scope.tableParams.total($scope.data.length);
                $scope.tableParams.reload()
                    .then(function () {
                        swal('Ok', 'ok', 'success'
                        );
                    });
            },
            function (response) {
                swal(
                    'Error',
                    response.statusText,
                    'error'
                );
            }
        );
    }; //end add function

    //fill form with the selected item
    $scope.fillFields = function (item) {
        $scope.contactId = item.contactId;
        $scope.name = item.name;
        $scope.phone = item.phone;
        $scope.email = item.email;
    };

    $scope.editContact = function (urlEdit) {
        $scope.contact =
            {
                'contactId': $scope.contactId,
                'name': $scope.name,
                'phone': $scope.phone,
                'email': $scope.email
            };
        for (var i = 0; i < $scope.data.length; i++) {
            if ($scope.data[i].contactId == $scope.contact.contactId) {
                $scope.data[i] = $scope.contact;
            }
        }
        $http.post(urlEdit, $scope.contact, config).then(
            function (response) {
                $scope.tableParams.total($scope.data.length);
                $scope.tableParams.reload()
                    .then(
                    function () {
                        swal('Ok', 'ok', 'success');
                    }
                    );
            },
            function (response) {
                swal('Ok', response.statusText, 'success');
            }
        );
    };//end edit function

    $scope.deleteContact = function (urlDelete, item) {
        swal({
            title: 'Are you sure?',
            text: "You won't be able to revert this!",
            type: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3086d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, Delete it!',
            cancelButtonText: 'No, Cancel!',
            confirmButtonClass: 'btn btn-success',
            cancelButtonClass: 'btn btn-danger',
            buttonsStyling: false,
            reverseButtons: true,
        }).then((result) => {
            if (result.value == true) {
                $scope.contact = item;

                $http.post(urlDelete, $scope.contact, config)
                    .then(function (response) {
                        $.each($scope.data, function (i) {
                            if ($scope.data[i].contactId === item.contactId) {
                                $scope.data.splice(i, 1);
                                return false;
                            }
                        });
                        $scope.tableParams.reload().then(function () {
                            swal('Ok', 'ok', 'success');
                        });
                    },
                    function (response) {
                        swal('Error', 'error', 'error');
                    }
                    );
            }
            else {
                swal('Cancelled', 'Your record is safe :)', 'success');
            }
        });
    };//end delete function



}]);
