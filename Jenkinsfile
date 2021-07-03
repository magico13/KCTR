pipeline {
    agent any

    stages {
        stage('Prepare') {
            steps {
                echo 'Preparing.'
                //unzip dlls
                sh 'curl https://magico13.net/files/KSP1.12.1.zip -o dlls.zip'
                sh 'unzip dlls.zip'
            }
        }
        stage('Build') {
            steps {
                echo 'Building..'
                sh '/usr/bin/msbuild KCTR.sln /property:Configuration=Release'
            }
        }
        stage('Test') {
            steps {
                echo 'Testing..'
            }
        }
        stage('Deploy') {
            steps {
                echo 'Deploying....'
                sh 'mkdir -p GameData/KCTR/Plugins'
                sh 'cp LICENSE GameData/KCTR/LICENSE.txt'
                sh 'cp -r KCTR/bin/Release/KCTR*.dll GameData/KCTR/Plugins/'
                sh 'zip -r KCTR.zip GameData'
                archiveArtifacts artifacts: 'KCTR.zip', followSymlinks: false
            }
        }
    }
}