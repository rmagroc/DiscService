var ViewModel = function () {
    var self = this;
    self.discs = ko.observableArray();
    self.error = ko.observable();

    var discsUri = '/api/discs/';

    function ajaxHelper(uri, method, data) {
        self.error(''); // Clear error message
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

    function getAllDiscs() {
        ajaxHelper(discsUri, 'GET').done(function (data) {
            self.discs(data);
        });
    }

    // lista los datos iniciales de los discos.
    getAllDiscs();



    // Muestra los detalles de cada disco
    self.detail = ko.observable();

    self.getDiscDetail = function (item) {
        ajaxHelper(discsUri + item.Id, 'GET').done(function (data) {
            self.detail(data);
        });
    }



    /* para agregar nuevos discos */
    self.singers = ko.observableArray();
    self.newDisc = {
        Singer: ko.observable(),
        Genre: ko.observable(),
        Price: ko.observable(),
        Title: ko.observable(),
        Year: ko.observable()
    }

    var singersUri = '/api/singers/';

    function getSingers() {
        ajaxHelper(singersUri, 'GET').done(function (data) {
            self.singers(data);
        });
    }

    self.addDisc = function (formElement) {
        var disc = {
            SingerId: self.newDisc.Singer().Id,
            Genre: self.newDisc.Genre(),
            Price: self.newDisc.Price(),
            Title: self.newDisc.Title(),
            Year: self.newDisc.Year()
        };

        ajaxHelper(discsUri, 'POST', disc).done(function (item) {
            self.discs.push(item);
            alert('Se actualizó correctamente.');
            //borramos los campos.
            $(':input', '#frmAddDisc')
              .not(':button, :submit, :reset, :hidden')
              .val('')
              .removeAttr('checked')
              .removeAttr('selected');
        });
    }

    
    /* para agregar nuevos cantantes */
    self.newSinger = {
        Nombre: ko.observable()
    }
    
    self.addSinger = function (formElement) {
        var singer = {
            Nombre: self.newSinger.Nombre()
        };

        ajaxHelper(singersUri, 'POST', singer).done(function (item) {
            self.singers.push(item);
            alert('Se actualizó correctamente.');
            //borramos los campos.
            $(':input', '#frmAddSinger')
              .not(':button, :submit, :reset, :hidden')
              .val('')
              .removeAttr('checked')
              .removeAttr('selected');
        });
    }

    /* para eliminar nuevos cantantes */

    var singersDelUri = '/api/singers/';

    self.actualSinger = {
        Id: ko.observable(),
        Nombre: ko.observable
    }

    self.delSinger = function (formElement) {
        var singer = {
            Id: self.actualSinger.Id(),
            Nombre: self.actualSinger.Nombre
        };

        ajaxHelper(singersUri, 'DELETE', singer).done(function (item) {
            self.singers.push(item);
            alert('Se eliminó correctamente.');
        });
    }

    getSingers();

};

ko.applyBindings(new ViewModel());