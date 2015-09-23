﻿@Section scripts
    @Scripts.Render("~/bundles/app")
End Section
<div class="page-header">
    <h1>DiscService</h1>
</div>

<div class="row">

    <div class="col-md-4">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h2 class="panel-title">Discs</h2>
            </div>
            <div class="panel-body">
                <ul class="list-unstyled" data-bind="foreach: discs">
                    <li>
                        <strong><span data-bind="text: SingerName"></span></strong>: <span data-bind="text: Title"></span>
                        <small><a href="#" data-bind="click: $parent.getDiscDetail">Details</a></small>
                    </li>
                </ul>
            </div>
        </div>
        <div class="alert alert-danger" data-bind="visible: error"><p data-bind="text: error"></p></div>
    </div>

    <!-- ko if:detail() -->

    <div class="col-md-4">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h2 class="panel-title">Detail</h2>
            </div>
            <table class="table">
                <tr><td>Singer</td><td data-bind="text: detail().SingerName"></td></tr>
                <tr><td>Title</td><td data-bind="text: detail().Title"></td></tr>
                <tr><td>Year</td><td data-bind="text: detail().Year"></td></tr>
                <tr><td>Genre</td><td data-bind="text: detail().Genre"></td></tr>
                <tr><td>Price</td><td data-bind="text: detail().Price"></td></tr>
            </table>
        </div>
    </div>

    <!-- /ko -->

    <div class="col-md-4">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h2 class="panel-title">Add Disc</h2>
            </div>

            <div class="panel-body">
                <form id="frmAddDisc" class="form-horizontal" data-bind="submit: addDisc">
                    <div class="form-group">
                        <label for="inputSinger" class="col-sm-2 control-label">Singer</label>
                        <div class="col-sm-10">
                            <select data-bind="options:singers, optionsText: 'Nombre', value: newDisc.Singer"></select>
                        </div>
                    </div>

                    <div class="form-group" data-bind="with: newDisc">
                        <label for="inputTitle" class="col-sm-2 control-label">Title</label>
                        <div class="col-sm-10">
                            <input type="text" class="form-control" id="inputTitle" data-bind="value:Title" />
                        </div>

                        <label for="inputYear" class="col-sm-2 control-label">Year</label>
                        <div class="col-sm-10">
                            <input type="number" class="form-control" id="inputYear" data-bind="value:Year" />
                        </div>

                        <label for="inputGenre" class="col-sm-2 control-label">Genre</label>
                        <div class="col-sm-10">
                            <input type="text" class="form-control" id="inputGenre" data-bind="value:Genre" />
                        </div>

                        <label for="inputPrice" class="col-sm-2 control-label">Price</label>
                        <div class="col-sm-10">
                            <input type="number" step="any" class="form-control" id="inputPrice" data-bind="value:Price" />
                        </div>
                    </div>
                    <button type="submit" class="btn btn-default">Submit</button>
                </form>
            </div>
        </div>
    </div>

    <div class="col-md-4">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h2 class="panel-title">Add Singer</h2>
            </div>

            <div class="panel-body">
                <form id="frmAddSinger" class="form-horizontal" data-bind="submit: addSinger">
                    <div class="form-group" data-bind="with: newSinger">
                        <label for="inputNombre" class="col-sm-2 control-label">Nombre</label>
                        <div class="col-sm-10">
                            <input type="text" class="form-control" id="inputNombre" data-bind="value:Nombre" />
                        </div>
                    </div>
                    <button type="submit" class="btn btn-default">Submit</button>
                </form>
            </div>
        </div>
    </div>

    <div class="col-md-4">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h2 class="panel-title">Delete Singer</h2>
            </div>

            <div class="panel-body">
                <form id="frmDelSinger" class="form-horizontal" data-bind="submit: delSinger">
                    <div class="form-group">
                        <label for="inputSinger" class="col-sm-2 control-label">Singer</label>
                        <div class="col-sm-10">
                            <select data-bind="options:singers, optionsText: 'Nombre', value: actualSinger.Singer"></select>
                        </div>
                    </div>
                    <button type="submit" class="btn btn-default">Delete</button>
                </form>
            </div>
        </div>
    </div>


</div>