
let {clean, restore, build, test, pack, publish, run} = require('gulp-dotnet-cli');
let gulp = require('gulp');
var browserSync = require('browser-sync');
var runCmd = require('gulp-run-command').default;

gulp.task('restore', ()=>{
    return gulp.src('**/*.csproj', {read: false})
            .pipe(restore());
});

gulp.task('build', ()=>{
    //this could be **/*.sln if you wanted to build solutions
return gulp.src('**/*.csproj', {read: false})
.pipe(build());
});


gulp.task('run',['serve'], ()=>{
    return gulp.src('AuthorizationAndAuthentication.csproj', {read: false})
            .pipe(run());
});


gulp.task('browserSynch', function () {
    browserSync.init({
        proxy: 'http://localhost:5000',
        host: 'localhost',
        open: 'local'
    });
    gulp.watch(["Views/Login/*.cshtml"
                    , "Views/Home/*.cshtml"]
                , 
            ).on("change", browserSync.reload);
});

gulp.task('net-watch', runCmd('dotnet watch run'));