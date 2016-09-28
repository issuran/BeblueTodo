var ViewModel = function () {
    var self = this;
    self.todoitems = ko.observableArray();
    self.error = ko.observable();

    var todoItemsUri = '/api/todoitems/';

    function ajaxHelper(uri, method, data) {
        self.error(''); //Clear error message
        return $.ajax({
            type: method,
            url: uri,
            dataType: 'json',
            contentType: 'application/json',
            data: data ? JSON.stringify(data) : null
        }).fail(function (jqXHR, textStatus, errorThrown) {
            self.error(errorThrown);
        });
    }
    function getAllTodoItems() {
        ajaxHelper(todoItemsUri, 'GET').done(function (data) {
            self.todoitems(data);
        });
    }

    self.detail = ko.observable();

    self.getTodoItemDetail = function (item) {
        ajaxHelper(todoItemsUri + item.Id, 'GET').done(function (data) {
            self.detail(data);
        });
    }

    self.people = ko.observableArray();
    self.newTodoItem = {
        Description: ko.observable(),
        IsDone: ko.observable()   
    }

    var peopleUri = '/api/people/';

    function getPeople() {
        ajaxHelper(peopleUri, 'GET').done(function (data) {
            self.people(data);
        });
    }

    self.addTodoItem = function (formElement) {
        var todoitem = {
            PersonId: self.newTodoItem.Person.Id,            
            Description: $("#Description").val(),
            IsDone: $("#IsDone").val()
        };

        ajaxHelper(todoItemsUri, 'POST', todoitem).done(function (item) {
            self.todoitems.push(item);
        });
    }

    getPeople();

    //Fetch the initial data.
    getAllTodoItems();
};

ko.applyBindings(new ViewModel());