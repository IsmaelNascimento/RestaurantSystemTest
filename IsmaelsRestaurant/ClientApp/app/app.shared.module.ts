import { RestaurantService } from './Services/restaurant.service';
import { PlateService } from './Services/plate.service';
import { PlateComponent } from './components/plate/plate.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { RestaurantComponent } from './components/restaurant/restaurant.component';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        RestaurantComponent,
        FetchDataComponent,
        HomeComponent,
        PlateComponent,
        
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'restaurants', component: RestaurantComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: 'plate', component: PlateComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers:[
        PlateService,
        RestaurantService
    ]
})
export class AppModuleShared {
}
